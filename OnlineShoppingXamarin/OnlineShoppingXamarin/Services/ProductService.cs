using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineShoppingXamarin.Model;

namespace OnlineShoppingXamarin.Services
{
    public class ProductService : IProductService
    {
        private string url = "http://eshopbasma.azurewebsites.net/api/Products";
        HttpClient httpClient = new HttpClient();
        
        public async Task< ObservableCollection<Product>> GetAllProducts()
        {
            var result = await httpClient.GetStringAsync(url);
            ObservableCollection<Product> products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(result);
            foreach(Product item in products)
            {
                item.Images =await GetProductImages(item.ID);
            }
           
            return products;
        }
        private async Task<Image> GetProductImage(Guid ProdId)
        {
            var Images = await GetProductImages(ProdId);
            return Images[0];
        }

        public async Task<ObservableCollection<Product>> GetFilterProducts(int min, int max)
        {
            var result = await httpClient.GetStringAsync(url+ "/filter/"+ min+"/"+ max);
            ObservableCollection<Product> products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(result);
            return products;
        }

        public async Task<Product> GetProduct(Guid ProductId)
        {
            var result = await httpClient.GetStringAsync(url+"/" + ProductId);
            Product product = JsonConvert.DeserializeObject<Product>(result);
            return product;
        }

        public async  Task<ObservableCollection<Image>> GetProductImages(Guid ProductId)
        {
           
            var result = await httpClient.GetStringAsync(url + "/Images/"+ ProductId );
            ObservableCollection<Image> productImages = JsonConvert.DeserializeObject<ObservableCollection<Image>>(result);
            return productImages;
        }
    }
}
