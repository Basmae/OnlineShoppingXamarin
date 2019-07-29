using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
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
        
        public String UserName { get; set; }
       
        public INavigation Navigation { get; set; }
       
        public Task<List<Product>> Products { get; set; }
        public Product SelectedProduct { get; set; }
        private IProductService ProductService;

        public HomeViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            ProductService = new ProductService();
            Products = ProductService.GetAllProducts();
            UserName =(string) Storage.GetProperty("UserName");
            
        }
       

      
    }
}
