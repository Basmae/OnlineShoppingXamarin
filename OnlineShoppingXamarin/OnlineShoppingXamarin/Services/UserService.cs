using Newtonsoft.Json;
using OnlineShoppingXamarin.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingXamarin.Services
{
    public class UserService : IUserService
    {
        private string url = "https://localhost:44367/api/users";
        HttpClient httpClient = new HttpClient();
        List<User> users = new List<User>()
        {
            new User
            {
                UserId=1,
                UserName="Basma"
            },
            new User
            {
                UserId=2,
                UserName="Ola"
            },
             new User
            {
                UserId=3,
                UserName="Ahmed"
            }
        };
        List<Cart> carts = new List<Cart>()
        {
            new Cart
            {
                CartId=1,
                IsSubmitted=false,
                ProductId=1,
                Quantity=1,
                UserId=1,
                Price=1000
            },
            new Cart
            {
                CartId=2,
                IsSubmitted=false,
                ProductId=2,
                Quantity=1,
                UserId=1,
                Price=1000
            },
            new Cart
            {
                CartId=3,
                IsSubmitted=false,
                ProductId=1,
                Quantity=1,
                UserId=2,
                Price=1000
            }

        };
        public void AddToCart(int UserId, int ProdId,int quantity)
        {
            carts.Add(new Cart
            {
                CartId=carts.Count+1,
                IsSubmitted=false,
                ProductId=ProdId,
                UserId=UserId,
                Quantity=quantity,
                Price=500
            });
        }

        public User GetUser(string userName)
        {
            foreach(User user in users)
            {
                if (user.UserName == userName)
                    return user;
            }
            return null;
        }

        public async Task<bool> UserExist(string userName)
        {
         //   var json = await httpClient.GetStringAsync(url+"/Name/" + userName);
            //var jj = json.Result;
           //  var User= JsonConvert.DeserializeObject<User>(json);
           foreach(var user in users)
            {
                if (user.UserName == userName)
                    return true;
            }
            return false;
        }
    }
}
