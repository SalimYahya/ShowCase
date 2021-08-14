using CrossPlatformApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CrossPlatformApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}