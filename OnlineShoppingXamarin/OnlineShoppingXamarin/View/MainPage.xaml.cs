using OnlineShoppingXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnlineShoppingXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MainPage : ContentPage
    {
        //public LoginViewModel DataContext { get; }

        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
            UserName.TextChanged += new EventHandler<TextChangedEventArgs>(ButtonEnabled);

        }
        private void ButtonEnabled(object sender ,EventArgs e)
        {
            if (UserNameValid() && !string.IsNullOrWhiteSpace(UserName.Text))
                Login.IsEnabled = true;
            else
                Login.IsEnabled = false;
        }
        private Boolean UserNameValid ()
        {
            foreach(char x in UserName.Text)
            {
                if (!(char.IsLetterOrDigit(x)))
                {
                    return false;
                }
            }
            return true;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Login.IsEnabled = false;
        }
    }
}
