using CrossPlatformApp.Services;
using CrossPlatformApp.Services.Contacts;
using CrossPlatformApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossPlatformApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IProductService, ProductService>();
            DependencyService.Register<IUserService, UserService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
