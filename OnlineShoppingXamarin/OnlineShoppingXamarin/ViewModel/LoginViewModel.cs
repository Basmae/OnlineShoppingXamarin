using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class LoginViewModel:PropertyChange
    {
       
        public string UserName { get; set; }
        public ICommand LoginCommand { get; private set; }
        public INavigation Navigation { get; set; }
       
        private IUserService UserService;
        private bool isLoading;
        public bool IsLoading { get=>isLoading; set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        } 

        public LoginViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            UserService = new UserService();
            LoginCommand = new Command(UserExist);
        }
        public async void UserExist()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    IsLoading = true;
                    bool Exist = await UserService.UserExist(UserName);
                    if (Exist)
                    {
                        Storage.SetProperty("UserName", UserName);
                        IsLoading = false;
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Login Error", "Please enter a valid name", "Ok");
                    }
                }
                catch (Exception e) {
                    await App.Current.MainPage.DisplayAlert("Internet Connection", "time out", "Cancel");

                }
            }
            else
                await App.Current.MainPage.DisplayAlert("Internet Connection","please turn on your Internet connection","Cancel");


        }

    }
}
