using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnlineShoppingXamarin.ViewModel
{
    public class FilterViewModel
    {
        public INavigation Navigation { get; set; }
        public int MinimumValue { get; set; } = 0;
        public int MaximumValue { get; set; } = 0;
        public ICommand ApplyFilterCommand { get; set; }
        public FilterViewModel(INavigation _Navigation)
        {
            Navigation = _Navigation;
            ApplyFilterCommand = new Command(ApplyFilter);
        }
        private async void ApplyFilter()
        {
            Storage.SetProperty("MinimumFilter", MinimumValue);
            Storage.SetProperty("MaximumFilter", MaximumValue);
            //await Navigation.PopModalAsync();
            // Storage.ReturnHome();
            Page opened = Storage.GetLastPage();
            await Navigation.PushAsync(new HomePage());
            Navigation.RemovePage(opened);
        }
    }
}
