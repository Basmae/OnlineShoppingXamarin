using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.ViewModel;
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
    public partial class ProductDetails : ContentPage
    {
        public ProductDetails(Product Product)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new ProductDetailsViewModel(Navigation,Product);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = (ProductDetailsViewModel)(BindingContext);
            vm.OnAppearing();
        }


    }
}