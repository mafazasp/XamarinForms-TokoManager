using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using TokoManager.Views;

namespace TokoManager.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginVM()
        {

        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        public Command SignUp
        {
            get
            {
                return new Command(()=> { App.Current.MainPage.Navigation.PushAsync(new SignUpPage()); });
            }
        }

        private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty
            
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
             await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                var user = await FirebaseHelper.GetUser(Email);
                if(user!=null)
                if (Email == user.Email && Security.Encrypt(Password) == user.Password)
                {
                await  App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                 await App.Current.MainPage.Navigation.PushAsync(new WelcomePage(Email));
                }
                else
                await  App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }
    }
}
