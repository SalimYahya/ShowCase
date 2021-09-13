using CrossPlatformApp.DTO.Special;
using CrossPlatformApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossPlatformApp.ViewModels
{
    public class ShoppingCartPageViewModel : BaseViewModel
    {
        private const string TAG = nameof(ShoppingCartPageViewModel);
        CancellationTokenSource source = new CancellationTokenSource();
        private IEnumerable<ProductInCartInfo> _productsList;

        public ObservableCollection<ProductInCartInfo> Products { get; }
        public Command LoadProductsInShoppinCartCommand { get; }
        public Command DeleteProductFromCartCommand { get; set; }
        public Command ConfirmOrederCommand { get; set; }

        public ShoppingCartPageViewModel()
        {
            Title = "Shopping Cart"; 
            ProductsList = GetShoppingCartProductsList();

            Products = new ObservableCollection<ProductInCartInfo>();
            LoadProductsInShoppinCartCommand = new Command(async ()=> await ExecuteLoadProductsInShoppinCartCommand());

            DeleteProductFromCartCommand = new Command(ExecuteDeleteProductFromCart);
            ConfirmOrederCommand = new Command(async ()=> await ExecuteConfirmOrder());
        }

        private async void ExecuteDeleteProductFromCart(object obj)
        {
            if (obj == null)
                return;

            await Task.Run(()=> {
                Debug.WriteLine($"DeleteProductFromCart()- obj: {obj}");
                ProductInCartInfo productInCartInfo = (ProductInCartInfo) obj;
                Debug.WriteLine($"DeleteProductFromCart()- productInCartInfo: {productInCartInfo}");

                MessagingCenter.Send("UpdateShoppingCart","Delete Product", productInCartInfo);
            });
        }

        private async Task ExecuteConfirmOrder()
        {
            await Task.Run(() => {
                Debug.WriteLine("ConfirmOrder()");
            });
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async Task ExecuteLoadProductsInShoppinCartCommand() 
        {
            await Task.Run(async ()=> {
                
                IsBusy = true;
                Debug.WriteLine($"{TAG} - TotalAmount: {TotalAmount}");

                await Task.Delay(2500, source.Token);

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
            });
        }

        public IEnumerable<ProductInCartInfo> ProductsList
        {
            get => _productsList;
            set => SetProperty(ref _productsList, value);
        }
    }
}
