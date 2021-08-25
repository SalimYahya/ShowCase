using CrossPlatformApp.DTO.Special;
using CrossPlatformApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossPlatformApp.ViewModels
{
    public class ShoppingCartPageViewModel : BaseViewModel
    {
        private int _totalProductsInCart;
        private IEnumerable<ProductInCartInfo> _productsList;

        public ObservableCollection<ProductInCartInfo> Products { get; }
        public Command LoadProductsInShoppinCartCommand { get; }

        public ShoppingCartPageViewModel()
        {
            Title = "Shopping Cart"; 
            ProductsList = GetShoppingCartProductsList();
            _totalProductsInCart = ProductsCount;

            Products = new ObservableCollection<ProductInCartInfo>();
            LoadProductsInShoppinCartCommand = new Command(() => ExecuteLoadProductsInShoppinCartCommand());
        }


        private void ExecuteLoadProductsInShoppinCartCommand() 
        {
            try
            {
                Products.Clear();
                var productsList = ProductsList;
                Debug.WriteLine($"{nameof(ShoppingCartPageViewModel)} : {productsList.ToString()}");

                if (productsList != null)
                {
                    foreach (var product in productsList)
                    {
                        Products.Add(product);
                        //Debug.WriteLine($"{nameof(ShoppingCartPageViewModel)} : {product.ToString()}");
                    }
                }
                else
                {
                    Debug.WriteLine($"{nameof(ShoppingCartPageViewModel)} : Empty");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing() 
        {
            IsBusy = true;
        }

        public int TotalProductsInCart 
        {
            get => _totalProductsInCart;
            set { _totalProductsInCart = ProductsCount; }
        }

        public IEnumerable<ProductInCartInfo> ProductsList
        {
            get => _productsList;
            set => SetProperty(ref _productsList, value);
        }
        
    }
}
