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
            BindingContext = signUpVM;

            var userProperties = new List<String>();
            Type type = typeof(User);
            PropertyInfo[] propertyinfo = type.GetProperties();
            foreach(PropertyInfo info in propertyinfo)
            {
                userProperties.Add(info.Name);
            }
            signUpForm.ItemsSource= userProperties;
        }
    }
}