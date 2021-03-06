﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TokoManager.ViewModels;

namespace TokoManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginVM loginVM;
        public LoginPage()
        {
            loginVM = new LoginVM();
            InitializeComponent();
            BindingContext = loginVM;
        }

        async void signupbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}