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
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new CartViewModel(Navigation);
            InitializeComponent();
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var vm = (CartViewModel)(BindingContext);
            var b = (TapGestureRecognizer)sender;

            var ob = b.CommandParameter as Cart;
            //vm.DeleteCommand.Execute(ob);
            vm.Delete(ob);
            

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = (CartViewModel)(BindingContext);
            vm.OnAppearing();
        }
    }
}