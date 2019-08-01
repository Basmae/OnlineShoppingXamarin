using Android.Widget;
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
    public class ProductDetailsViewModel:PropertyChange
    {
        private Product product { get; set; }
        public Product Product { get=>product; set {
                if (product != value)
                {
                    product = value;
                    OnPropertyChanged(nameof(Product));
                }
            } }
        public IProductService ProductService { get; set; }
        public IUserService UserService { get; set; }

        public INavigation Navigation { get; set; }
        public int Counter { get; set; } = 1;
        public ICommand IncreaseCounter { get; set; }
        public ICommand DecreaseCounter { get; set; }
        public ICommand AddToCart { get; set; }
        private ObservableCollection<Model.Image> productImages { get; set; }
        public ObservableCollection<Model.Image> ProductImages { get=>productImages; set {
                if (productImages != value)
                {
                    productImages = value;
                    OnPropertyChanged(nameof(ProductImages));
                }
            } }
       
        private Guid ProductID { get; set; }

        public ProductDetailsViewModel(INavigation _Navigation, Product sProduct)
        {
            Navigation = _Navigation;
            Product = sProduct;
            ProductID = Product.ID;
            IncreaseCounter = new Command(UpCounter);
            DecreaseCounter = new Command(DownCounter);
            AddToCart = new Command(AddCart);
            ProductService = new ProductService();
            UserService = new UserService();
           
        }
        public void OnAppearing()
        {
            GetData();
        }
        public async void GetData()
        {
            ProductImages = await ProductService.GetProductImages(ProductID);
           // Product = await ProductService.GetProduct(ProductID);
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
            User user =await UserService.GetUser(Storage.GetProperty("UserName").ToString());
            UserService.AddToCart(user.Id, Product, Counter);
            // Storage.ReturnHome();
            Page opened = Storage.GetLastPage();
            await Navigation.PushAsync(new HomePage());
            Navigation.RemovePage(opened);
        }
    }
}
