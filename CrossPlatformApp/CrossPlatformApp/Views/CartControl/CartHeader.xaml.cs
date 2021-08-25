using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrossPlatformApp.Views.CartControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartHeader : Grid
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CartHeader));

        public static readonly BindableProperty ProductsCountProperty =
            BindableProperty.Create("ProductsCount", typeof(int), typeof(CartHeader));

        public static readonly BindableProperty GoToCartCommandProperty =
            BindableProperty.Create("GoToCartCommand", typeof(Command), typeof(CartHeader));


        public int ProductsCount
        {
            get => (int)GetValue(ProductsCountProperty);
            set => SetValue(ProductsCountProperty, value);

        }
        public string Title 
        {
            get => (string)GetValue(TitleProperty); 
            set => SetValue(TitleProperty, value);
        }

        public Command GoToCartCommand
        {
            get => (Command)GetValue(GoToCartCommandProperty);
            set => SetValue(GoToCartCommandProperty, value); 
        }

        public CartHeader()
        {
            InitializeComponent();
        }
    }
}