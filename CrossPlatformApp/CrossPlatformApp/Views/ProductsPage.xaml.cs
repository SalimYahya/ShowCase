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
    public partial class ProductsPage : ContentPage
    {
        ProductsViewModel _productsViewModel;

        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = _productsViewModel = new ProductsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _productsViewModel.OnAppearing();
        }
    }
}