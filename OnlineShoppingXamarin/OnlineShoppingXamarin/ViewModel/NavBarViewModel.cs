using OnlineShoppingXamarin.Services;
using OnlineShoppingXamarin.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class NavBarViewModel:PropertyChange
    {
        public String UserName { get; set; }

        public INavigation Navigation { get; set; }
        public IUserService UserService { get; set; }
        public ICommand MenuCommand { get; private set; }
        public ICommand CartCommand { get; private set; }
       private int cartCounter { get; set; }
        public int CartCounter { get=>cartCounter; set {
                if (cartCounter != value)
                {
                    cartCounter = value;
                    OnPropertyChanged(nameof(CartCounter));
                }
            } }

        public NavBarViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            UserService = new UserService();
            UserName = (string)Storage.GetProperty("UserName");
            MenuCommand = new Command(OpenMenu);
            CartCommand = new Command(OpenCart);
            GetData();
            
        }
        private async void GetData()
        {
            CartCounter =await UserService.GetCartCounter(UserName);

        }

        private async void OpenMenu()
        {
            string action;
            var stack = App.Current.MainPage.Navigation.NavigationStack;
            Page openedPage = stack[stack.Count - 1];
           if ( openedPage is HomePage)
               action =await App.Current.MainPage.DisplayActionSheet("Menu", "cancel", null,"Home","Filter","Sync","Logout");
           else
                action = await App.Current.MainPage.DisplayActionSheet("Menu", "cancel", null, "Home", "Sync", "Logout");
            switch (action)
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
            
            Page openedPage = Storage.GetLastPage();
            if (!(openedPage is CartPage))
            {
                await Navigation.PushAsync(new CartPage());
                Navigation.RemovePage(openedPage);

            }
        }
        private async void NavHome()
        {
            Page openedPage = Storage.GetLastPage();

            if (!(openedPage is HomePage))
            {
                await Navigation.PushAsync(new HomePage());
                Navigation.RemovePage(openedPage);
            }
        }
        private async void NavFilter()
        {
            await Navigation.PushAsync(new FilterPage());
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
