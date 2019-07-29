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
        Task<Product> GetProduct(Guid ProductId);
    }
}
