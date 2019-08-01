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
            int min, max;
            if (Storage.GetProperty("MinimumFilter") == null && Storage.GetProperty("MaximumFilter") == null)
            {
                min = 0;
                max = 0;
            }
            else
            {
                min = (int)Storage.GetProperty("MinimumFilter");
                max = (int)Storage.GetProperty("MaximumFilter");
            }
            if (min == 0 && max == 0)
                Products = ProductService.GetAllProducts().Result;
            else
                Products = ProductService.GetFilterProducts(min, max);
            Storage.SetProperty("MinimumFilter",0);
            Storage.SetProperty("MaximumFilter", 0);
            DetailsCommand = new Command(ProductSelected);
           
        }

        private async void ProductSelected()
        {
            Storage.SetProperty("SelectedProduct", SelectedProduct);
             await Navigation.PushAsync(new ProductDetails(SelectedProduct.ProductId));
        }

       

    }
}
