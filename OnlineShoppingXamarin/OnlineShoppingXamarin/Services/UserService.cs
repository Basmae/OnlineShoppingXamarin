using Newtonsoft.Json;
using OnlineShoppingXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingXamarin.Services
{
    public class UserService : IUserService
    {
        private string url = "http://eshopbasma.azurewebsites.net/api/";
        HttpClient httpClient = new HttpClient();
        ProductService ProductService = new ProductService();
       
        public async void AddToCart(Guid UserId, Product Prod,int quantity)
        {
           // Product product = await ProductService.GetProduct(ProdId);
            Cart cart = new Cart
            {
                UserId = UserId,
                ProductId = Prod.ID,
                IsSubmitted = false,
                Quantity = quantity,
                Price = quantity * Prod.Price
            };
            var json = JsonConvert.SerializeObject(cart);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(url + "Carts",content );
        }

        public async void DeleteCart(Cart cart)
        {
            var json = JsonConvert.SerializeObject(cart);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
           await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, url+"Carts")
            { Content =content});

        }

        public async Task<int> GetCartCounter(string userName)
        {
            var User = await GetUser(userName);
            var carts = await GetUserCarts(User.Id);
            return carts.ToList().Count;
        }

        public async Task<User> GetUser(string userName)
        {
           var result = await httpClient.GetStringAsync(url+"Users/Name/" + userName);
            User user = JsonConvert.DeserializeObject<User>(result);
            return user;
          
        }

        public async Task<ObservableCollection<Cart>> GetUserCarts(Guid UserId)
        {
            var result = await httpClient.GetStringAsync(url + "carts/" + UserId);
            ObservableCollection<Cart> carts =  JsonConvert.DeserializeObject<ObservableCollection<Cart>>(result);
            return  carts;

        }

        public async void SubmitOrder(Guid UserId)
        {
            var json = JsonConvert.SerializeObject(UserId);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(url + "Order/Submit/"+UserId, content);
        }

        public async Task<bool> UserExist(string userName)
        {
            var x =await httpClient.GetStringAsync(url+"Users/Name/" + userName);
            var user= JsonConvert.DeserializeObject<User>(x);
            
            if (user != null)
                return true;
            else
                return false;
          
        }

    }
}
