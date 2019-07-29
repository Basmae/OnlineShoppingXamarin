using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class LoginViewModel
    {
       
        public string UserName { get; set; }
        public ICommand LoginCommand { get; private set; }
        public INavigation Navigation { get; set; }
       
        private IUserService UserService;

        public LoginViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            UserService = new UserService();
            LoginCommand = new Command(UserExist);
        }
        public async void UserExist()
        {
            if (await UserService.UserExist(UserName))
            {
                Storage.SetProperty("UserName", UserName);
                await Navigation.PushModalAsync(new HomePage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Login Error", "Please enter a valid name", "Ok");
            }



        }

    }
}
