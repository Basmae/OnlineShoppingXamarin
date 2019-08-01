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
    public partial class CartItemView : ContentView
    {
        public CartItemView()
        {
            InitializeComponent();
        }
    }
}