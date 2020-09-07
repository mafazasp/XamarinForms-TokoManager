using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TokoManager.ViewModels;
using TokoManager.Models;
using System.Reflection;

namespace TokoManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        SignUpVM signUpVM;
        public SignUpPage()
        {
            
            InitializeComponent();
            signUpVM = new SignUpVM();
            //BindingContext = signUpVM;

            Type type = typeof(UserDetail);
            PropertyInfo[] propertyinfo = type.GetProperties();
            var userProperties = new List<Property>();
            int index = 0;
            foreach (PropertyInfo info in propertyinfo)
            {
                userProperties.Insert(index, new Property { Name = info.Name, Type = info.PropertyType});
                index++;
            }


                detailForm.ItemsSource= userProperties;
        }
    }
}