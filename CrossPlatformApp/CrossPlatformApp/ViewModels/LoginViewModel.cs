using CrossPlatformApp.DTO.Account;
using CrossPlatformApp.Services;
using CrossPlatformApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CrossPlatformApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public const string USER_NAME = "john@doe.com";
        public const string PASSWORD = "123456";

        public const string TAG = nameof(LoginViewModel);

        private string _username;
        private string _password;

        private bool _isLoginInvalid;
        private bool _isPasswordInvalid;

        public Command LoginCommand { get; }
        
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {

            Debug.WriteLine($"Usename: {_username} - Password: {_password}");

            if (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password))
            {
                Login login = new Login { Email = USER_NAME, Password = PASSWORD };

                try
                {
                    var loginResult = await _userService.Login(login);
                    if (loginResult != null) 
                    {
                        Debug.WriteLine($"{TAG}: Token - { await SecureStorage.GetAsync("jwtToken-token") }");
                        Debug.WriteLine($"{TAG}: Token -  {await SecureStorage.GetAsync("jwtToken-refresh-token") }");
                        Debug.WriteLine($"{TAG}: Token - { await SecureStorage.GetAsync("jwtToken-epire-date") }");
                    }

                    if(loginResult.Success)
                        // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                        await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

                    // If Login Not success
                    string errorMsg = "";
                    foreach (var error in loginResult.Errors)
                        errorMsg += error + " | ";

                    if (!loginResult.Success)
                        Debug.WriteLine($"{TAG}: {errorMsg}");
                }
                catch (Exception ex) { Debug.WriteLine($"{TAG}: {ex}"); }
                finally { IsBusy = false; }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e) 
        {
        }

        public void OnAppearing()
        {
            IsBusy = true;

            Username = null;
            Password = null;
        }

        public string Username 
        {
            get => _username;
            set{ SetProperty(ref _username, value); }
        }

        public string Password
        {
            get => _password;
            set { SetProperty(ref _password, value);  }
        }

        public bool IsLoginInvalid 
        {
            get => _isLoginInvalid;
            set { SetProperty(ref _isLoginInvalid, value); }
        }
        public bool IsPasswordInvalid 
        {
            get => _isPasswordInvalid;
            set { SetProperty(ref _isPasswordInvalid, value); }
        }
    }
}
