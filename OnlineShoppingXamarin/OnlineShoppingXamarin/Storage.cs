using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnlineShoppingXamarin
{
    public class Storage
    {
        //public string UserName { get; set; }
        public static object GetProperty(string propertyKey)
        {
            object retValue = null;
            IDictionary<string, object> properties = App.Current.Properties;
            if (properties.ContainsKey(propertyKey))
            {
                retValue = properties[propertyKey];
            }
            return retValue;
        }

        public static void SetProperty(string propertyKey, object obj)
        {
            IDictionary<string, object> properties = App.Current.Properties;
            if (properties.ContainsKey(propertyKey))
            {
                properties[propertyKey] = obj;
            }
            else
            {
                properties.Add(propertyKey, obj);
            }
        }
        public static async void ReturnHome()
        {
            var stack = App.Current.MainPage.Navigation.NavigationStack;
            for(int i=stack.Count-1;i>0;i--)
            {
                if (stack[i] is MainPage)
                {
                    break;
                }
                else
                    await App.Current.MainPage.Navigation.PopAsync();
            }
        }
        public static Page GetLastPage()
        {
            var stack = App.Current.MainPage.Navigation.NavigationStack;
            Page opened = stack[stack.Count - 1];
            return opened;
        }
    }
}
