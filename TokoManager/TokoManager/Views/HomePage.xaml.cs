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
	public partial class HomePage : ContentPage
	{
        UserInfoVM userInfoVM;
		public HomePage (string username)
		{
			InitializeComponent();
			userInfoVM = new UserInfoVM(username);
            BindingContext = userInfoVM;
		}
	}
}