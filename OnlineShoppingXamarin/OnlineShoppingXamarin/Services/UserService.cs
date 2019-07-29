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
                UserId=Guid.NewGuid(),
                UserName="Basma"
            },
            new User
            {
                UserId=Guid.NewGuid(),
                UserName="Ola"
            },
             new User
            {
                UserId=Guid.NewGuid(),
                UserName="Ahmed"
            }
        };
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
