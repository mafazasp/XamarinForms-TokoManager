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
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
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
            //null or empty field validation, check weather username and password is null or empty
            
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
             await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Username and Password", "OK");
            else
            {
                var user = await UserVM.GetUser(Username);
                if(user!=null)
                if (Username == user.Username && Security.Encrypt(Password) == user.Password)
                {
                await  App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                 await App.Current.MainPage.Navigation.PushAsync(new HomePage(Username));
                }
                else
                await  App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Username and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }
    }
}
