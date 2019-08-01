using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class CartViewModel:PropertyChange
    {
        public INavigation Navigation { get; set; }
        public ICommand SubmitCommand { get; set; }
        private ObservableCollection<Cart> carts { get; set; }
        private User user { get; set; }
        public User User { get => user; set {
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            } }
        public ObservableCollection<Cart> Carts { get=>carts; set {
                if (carts != value)
                {
                    carts = value;
                    OnPropertyChanged(nameof(Carts));
                }
            } }
        private IUserService UserService { get; set; }
        private IProductService ProductService { get; set; }
        public CartViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            UserService = new UserService();
            ProductService = new ProductService();
            SubmitCommand = new Command(SubmitOrder);

        }
        public void OnAppearing()
        {
            GetData();
        }
        private async void GetData()
        {
            User = await UserService.GetUser(Storage.GetProperty("UserName").ToString());

            Carts = await UserService.GetUserCarts(User.Id);
            

        }
        public async void SubmitOrder()
        {
            UserService.SubmitOrder(User.Id);
            Page opened = Storage.GetLastPage();
            await Navigation.PushAsync(new HomePage());
            Navigation.RemovePage(opened);
        }
    }
}
