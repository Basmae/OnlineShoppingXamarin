﻿using System;
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
       
        public static Page GetLastPage()
        {
            var stack = App.Current.MainPage.Navigation.NavigationStack;
            Page opened = stack[stack.Count - 1];
            return opened;
        }
    }
}
