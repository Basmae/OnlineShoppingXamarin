using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class CartViewModel
    {
        public INavigation Navigation { get; set; }
        public List<Cart> Carts { get; set; }
        private IUserService UserService { get; set; }
        private IProductService ProductService { get; set; }
        public CartViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            UserService = new UserService();
            ProductService = new ProductService();
            User User = UserService.GetUser(Storage.GetProperty("UserName").ToString());
            Carts = UserService.GetUserCarts(User.UserId);
           
           
        }
    }
}
