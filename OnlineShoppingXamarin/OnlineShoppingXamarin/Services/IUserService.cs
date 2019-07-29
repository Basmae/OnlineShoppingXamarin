using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingXamarin.Services
{
    public interface IUserService
    {
         Task<Boolean> UserExist(string userName);
         

    }
}
