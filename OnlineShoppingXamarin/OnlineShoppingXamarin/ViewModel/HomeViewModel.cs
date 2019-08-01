using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
using OnlineShoppingXamarin.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class HomeViewModel:PropertyChange
    {

       
        public INavigation Navigation { get; set; }
       
        private ObservableCollection<Product> products { get; set; }
        public ObservableCollection<Product> Products { get=>products;
            set
            {
                if(products!=value)
                {
                    products=value;
                    OnPropertyChanged(nameof(Products));
                }
            }
            }
        private Product selectedProduct { get; set; }
        public Product SelectedProduct { get => selectedProduct; set {
                if (selectedProduct != value)
                {
                    selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            } }
        private IProductService ProductService;


        public ICommand DetailsCommand { get; private set; }
       
        public HomeViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            ProductService = new ProductService();
            DetailsCommand = new Command(ProductSelected);
           
           
        }
        public async void OnAppearing()
        {
             GetData();
        }
        private async void GetData()
        {
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
                Products = await  ProductService.GetAllProducts();
            else
                Products = await ProductService.GetFilterProducts(min, max);

            Storage.SetProperty("MinimumFilter", 0);
            Storage.SetProperty("MaximumFilter", 0);

        }
        private async void ProductSelected()
        {
            Storage.SetProperty("SelectedProduct", SelectedProduct);
             await Navigation.PushAsync(new ProductDetails(SelectedProduct));
        }

       

    }
}
