using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.Services;
using OnlineShoppingXamarin.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class CartViewModel:PropertyChange
    {
        public INavigation Navigation { get; set; }
        public ICommand SubmitCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private Cart selectedCart;
        public Cart SelectedCart
        {
            get => selectedCart; set
            {
                if (selectedCart != value)
                {
                    selectedCart = value;
                    OnPropertyChanged(nameof(SelectedCart));
                }
            }
        }

        private ObservableCollection<Cart> carts { get; set; }
        private User user { get; set; }
        public User User { get => user; set {
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            } }
       
        public ObservableCollection<Cart> Carts { get=>carts; set {
                if (carts != value)
                {
                    carts = value;
                    OnPropertyChanged(nameof(Carts));
                }
            } }
        private IUserService UserService { get; set; }
        private IProductService ProductService { get; set; }
        public CartViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            UserService = new UserService();
            ProductService = new ProductService();
            SubmitCommand = new Command(SubmitOrder);
            DeleteCommand = new Command<Cart>(Delete);


        }
        public void OnAppearing()
        {
            GetData();
        }
        private async void GetData()
        {
            User = await UserService.GetUser(Storage.GetProperty("UserName").ToString());

            ObservableCollection<Cart> UserCart = await UserService.GetUserCarts(User.Id);
            foreach (Cart cart in UserCart)
            {
                cart.ProductName =await ProductService.GetProductName(cart.ProductId);
                var I = await ProductService.GetProductImages(cart.ProductId);
                cart.Product = await ProductService.GetProduct(cart.ProductId);
                cart.Product.ImageUrl = I[0].ImageUrl;
            }
            Carts = UserCart;

        }
        public async void SubmitOrder()
        {
            UserService.SubmitOrder(User.Id);
            Page opened = Storage.GetLastPage();
            await Navigation.PushAsync(new HomePage());
            Navigation.RemovePage(opened);
        }
        public async void Delete(Cart cart)
        {
            
            UserService.DeleteCart(cart);
            Carts.Remove(cart);
            MessagingCenter.Send(this, "CartUpdated", cart);

            //Navigation.PushAsync(new HomePage());
        }
    }
}
