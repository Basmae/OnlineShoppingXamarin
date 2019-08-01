using OnlineShoppingXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingXamarin.Services
{
    public interface IUserService
    {
         Task<Boolean> UserExist(string userName);
        void AddToCart(Guid UserId, Product Prod,int quantity);
        Task<User> GetUser(string userName);
        Task<ObservableCollection<Cart>> GetUserCarts(Guid UserId);
        Task<int> GetCartCounter(string userName);
        void SubmitOrder(Guid UserId);
        void DeleteCart(Cart cart);
       

    }
}
