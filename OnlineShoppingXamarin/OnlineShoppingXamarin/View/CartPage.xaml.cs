﻿using OnlineShoppingXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineShoppingXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new CartViewModel(Navigation);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = (CartViewModel)(BindingContext);
            vm.OnAppearing();
        }
    }
}