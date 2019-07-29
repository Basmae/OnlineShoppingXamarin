using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
using OnlineShoppingXamarin.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class HomeViewModel
    {
        
       
        public INavigation Navigation { get; set; }
       
        public List<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        private IProductService ProductService;
       
        public ICommand DetailsCommand { get; private set; }

        public HomeViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            ProductService = new ProductService();
            Products = ProductService.GetAllProducts().Result;
            DetailsCommand = new Command(ProductSelected);
           
        }

        private async void ProductSelected()
        {
            Storage.SetProperty("SelectedProduct", SelectedProduct);
             await Navigation.PushAsync(new ProductDetails());
        }

       

    }
}
