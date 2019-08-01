using OnlineShoppingXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingXamarin.Services
{
    public interface IProductService
    {
         Task<ObservableCollection<Product>> GetAllProducts();
        Task<Product> GetProduct(Guid ProductId);
        Task<ObservableCollection<Image>> GetProductImages(Guid ProductId);
        Task<ObservableCollection<Product>> GetFilterProducts(int min, int max);
        Task<String> GetProductName(Guid ProductId);
    }
}
