using Android.Widget;
using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace OnlineShoppingXamarin.ViewModel
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public IProductService ProductService { get; set; }
        public IUserService UserService { get; set; }

        public INavigation Navigation { get; set; }
        public int Counter { get; set; } = 1;
        public ICommand IncreaseCounter { get; set; }
        public ICommand DecreaseCounter { get; set; }
        public ICommand AddToCart { get; set; }
        public List<Model.Image> ProductImages { get; set; }

        public ProductDetailsViewModel(INavigation _Navigation, int ProductId)
        {
            Navigation = _Navigation;
            IncreaseCounter = new Command(UpCounter);
            DecreaseCounter = new Command(DownCounter);
            AddToCart = new Command(AddCart);
            ProductService = new ProductService();
            UserService = new UserService();
            ProductImages = ProductService.GetProductImages(ProductId);
            Product = ProductService.GetProduct(ProductId);
        }
        private void UpCounter()
        {
            Counter++;
        }
        private void DownCounter()
        {
            if(Counter>1)
                 Counter--;
        }
        private async void AddCart()
        {
            User user = UserService.GetUser(Storage.GetProperty("UserName").ToString());
            UserService.AddToCart(user.UserId, Product.ProductId, Counter);
            await Navigation.PushAsync(new HomePage());
        }
    }
}
