using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using TokoManager.Views;

namespace TokoManager.ViewModels
{
   public class SignUpVM: INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }
        public Command SignUpCommand
        {
            get
            {
                return new Command(() => 
                {
                    if (Password == ConfirmPassword)
                        SignUp();
                    else
                         App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                } );
            }
        }
        private async void SignUp()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                var user = await FirebaseHelper.AddUser(Email,Security.Encrypt(Password));
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("SignUp Success", "", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new WelcomePage(Email));
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");
               
            }
        }
    }
}
