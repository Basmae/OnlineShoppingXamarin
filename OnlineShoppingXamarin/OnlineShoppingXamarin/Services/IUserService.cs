using OnlineShoppingXamarin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingXamarin.Services
{
    public interface IUserService
    {
         Task<Boolean> UserExist(string userName);
        void AddToCart(int UserId, int ProdId,int quantity);
        User GetUser(string userName);
        List<Cart> GetUserCarts(int UserId);
        int GetCartCounter(string userName);
       

    }
}
