using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingXamarin.Model;

namespace OnlineShoppingXamarin.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products = new List<Product>()
        {
            new Product
            {
                ProductId=Guid.NewGuid(),
                ProductName="product1",
                Description="this is the first product ay kalam kteeer 3n el product da",
                Price=500,
                Quantity=10,
                ImageUrl="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05962448.png"
            },
             new Product
            {
                ProductId=Guid.NewGuid(),
                ProductName="product2",
                Description="this is the second product ay kalam kteeer 3n el product da",
                Price=1000,
                Quantity=2,
                 ImageUrl="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05962448.png"
            }
        };
        public async Task< List<Product>> GetAllProducts()
        {
            var sortedProducts = products.OrderBy(p => p.Price).ToList();
            return sortedProducts;
        }

        public async Task<Product> GetProduct(Guid ProductId)
        {
            foreach(var prod in products)
            {
                if (prod.ProductId == ProductId)
                    return prod;
            }
            return null;
        }
    }
}
