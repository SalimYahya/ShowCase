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
    public partial class ShoppingCartPage : ContentPage
    {
        ShoppingCartPageViewModel _shoppingCartPageViewModel;

        public ShoppingCartPage()
        {
            InitializeComponent();
            BindingContext = _shoppingCartPageViewModel = new ShoppingCartPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _shoppingCartPageViewModel.OnAppearing();
        }
    }
}