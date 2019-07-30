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
                ProductId=1,
                ProductName="product1",
                Description="this is the first product ay kalam kteeer 3n el product da",
                Price=500,
                Quantity=10,
                ImageUrl="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05962448.png"
            },
             new Product
            {
                ProductId=2,
                ProductName="product2",
                Description="this is the second product ay kalam kteeer 3n el product da",
                Price=1000,
                Quantity=2,
                 ImageUrl="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05962448.png"
            }
        };
        private List<Image> Images = new List<Image>()
        {
            new Image
            {
                ImageId=1,
                ImageUrl="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05962448.png",
                ProductId=1
            },
             new Image
            {
                ImageId=2,
                ImageUrl="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05962448.png",
                ProductId=1
            },
              new Image
            {
                ImageId=3,
                ImageUrl="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05962448.png",
                ProductId=2
            },
               new Image
            {
                ImageId=4,
                ImageUrl="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05962448.png",
                ProductId=2
            },
              new Image
            {
                ImageId=5,
                ImageUrl="https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c05962448.png",
                ProductId=2
            }
        };
        public async Task< List<Product>> GetAllProducts()
        {
            var sortedProducts = products.OrderBy(p => p.Price).ToList();
            return sortedProducts;
        }

        public Product GetProduct(int ProductId)
        {
            foreach(var prod in products)
            {
                if (prod.ProductId == ProductId)
                    return prod;
            }
            return null;
        }

        public List<Image> GetProductImages(int ProductId)
        {
            List<Image> ProductImages = new List<Image>();
            foreach (Image image in Images)
            {
                if (image.ProductId == ProductId)
                    ProductImages.Add(image);
            }
            return ProductImages;
        }
    }
}
