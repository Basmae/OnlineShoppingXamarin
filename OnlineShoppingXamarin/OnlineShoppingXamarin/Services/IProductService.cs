using OnlineShoppingXamarin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingXamarin.Services
{
    public interface IProductService
    {
         Task<List<Product>> GetAllProducts();
        Product GetProduct(int ProductId);
        List<Image> GetProductImages(int ProductId);
        List<Product> GetFilterProducts(int min, int max);
    }
}
