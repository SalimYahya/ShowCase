using CrossPlatformApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossPlatformApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel _loginViewModel;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = _loginViewModel = new LoginViewModel();

            Username.Completed += (object sender, EventArgs e) => { Passowrd.Focus(); };
            Passowrd.Completed += (object sender, EventArgs e) => { _loginViewModel.LoginCommand.Execute(null); };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _loginViewModel.OnAppearing();
        }
    }
}