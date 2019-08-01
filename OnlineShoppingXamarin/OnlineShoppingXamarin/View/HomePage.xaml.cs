using OnlineShoppingXamarin.Model;
using OnlineShoppingXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineShoppingXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
       // public HomeViewModel DataContext { get; }

        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new HomeViewModel(Navigation);

        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var vm = (HomeViewModel)(BindingContext);
            vm.DetailsCommand.Execute((Product)e.SelectedItem);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = (HomeViewModel)(BindingContext);
            vm.OnAppearing();
        }
       
    }
}