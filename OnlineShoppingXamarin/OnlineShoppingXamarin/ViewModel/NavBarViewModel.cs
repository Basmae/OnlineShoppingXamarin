using OnlineShoppingXamarin.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class NavBarViewModel
    {
        public String UserName { get; set; }

        public INavigation Navigation { get; set; }

        public ICommand MenuCommand { get; private set; }
        public ICommand CartCommand { get; private set; }
       
        public bool MenuIsVisible { get; set; } = true;
        public int CartCounter { get; set; }

        public NavBarViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            Storage.SetProperty("CartCounter", 4);
            UserName = (string)Storage.GetProperty("UserName");
            CartCounter = (int)Storage.GetProperty("CartCounter");
            MenuCommand = new Command(OpenMenu);
            CartCommand = new Command(OpenCart);
        }

        private async void OpenMenu()
        {
           
          var action =await App.Current.MainPage.DisplayActionSheet("Menu", "cancel", null,"Home","Filter","Sync","Logout");
         switch(action)
            {
                case "Home":
                    NavHome();
                    break;
                case "Filter":
                    NavFilter();
                    break;
                case "Sync":
                    NavSync();
                    break;
                case "Logout":
                    NavLogout();
                    break;
            }
        }
        private async void OpenCart()
        {
           await Navigation.PushAsync(new CartPage());
        }
        private async void NavHome()
        {
           await Navigation.PushAsync(new HomePage());
        }
        private void NavFilter()
        {
        }
        private void NavSync()
        {
        }
        private async void NavLogout()
        {
            Storage.SetProperty("UserName", null);
            
           await Navigation.PopToRootAsync();
        }
    }
}
