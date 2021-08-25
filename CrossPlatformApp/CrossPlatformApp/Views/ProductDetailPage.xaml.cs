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
    public partial class ProductDetailPage : ContentPage
    {
        ProductDetailViewModel _productDetailViewModel;
        public ProductDetailPage()
        {
            InitializeComponent();
            BindingContext = _productDetailViewModel = new ProductDetailViewModel();
        }
    }
}