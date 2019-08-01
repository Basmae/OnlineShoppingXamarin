using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class CartItemViewModel
    {
        private Cart myCart;
        public ICommand DeleteCommand;
        private IUserService UserService;

        public CartItemViewModel(Cart cart)
        {
            myCart = cart;
            DeleteCommand = new Command(Delete);
            UserService = new UserService();
        }

        public string ImageUrl => myCart.Product.ImageUrl;
        public string ProductName => myCart.ProductName;
        public double Quantity => myCart.Product.Quantity;

        void Delete()
        {
            App.Current.MainPage.Navigation.PushAsync(new HomePage());
            UserService.DeleteCart(myCart);
        }
    }
}
