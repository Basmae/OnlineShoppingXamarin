using OnlineShoppingXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            InitializeComponent();
            BindingContext = new HomeViewModel(Navigation);

        }
    }
}