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
            productImages = new ObservableCollection<Model.Image>();
            productImages.Add(new Model.Image
            {
                ImageUrl = "https://res.cloudinary.com/practicaldev/image/fetch/s--bIcIUu5D--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://thepracticaldev.s3.amazonaws.com/i/t7u2rdii5u9n4zyqs2aa.jpg"
            });
           
           
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
            if (Product.Quantity >= Counter)
            {
                User user = await UserService.GetUser(Storage.GetProperty("UserName").ToString());
                UserService.AddToCart(user.Id, Product, Counter);
                Page opened = Storage.GetLastPage();
                DependencyService.Get<IMessage>().Message("Cart updated successfully");
                await Navigation.PushAsync(new HomePage());
                Navigation.RemovePage(opened);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("", "sorry the available quantity is less than your order", "OK");
            }
           
        }
    }
}
