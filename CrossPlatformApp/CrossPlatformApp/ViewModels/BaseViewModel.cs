using CrossPlatformApp.DTO.Special;
using CrossPlatformApp.Models;
using CrossPlatformApp.Services;
using CrossPlatformApp.Services.Contacts;
using CrossPlatformApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CrossPlatformApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private int _productsCount;

        public IProductService _productService => DependencyService.Get<IProductService>();
        public IUserService _userService => DependencyService.Get<IUserService>();
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        public Command GoToCartCommand { get; private set; }

        public BaseViewModel()
        {
            SubscribeToEvent();
            Initialize();
            GoToCartCommand = new Command(NavigateToCartAsync);
        }

        private async void NavigateToCartAsync()
        {
            Debug.WriteLine($"Navigate to Basket - ProductsCount : {ProductsCount}");
            await Shell.Current.GoToAsync($"..//{nameof(ShoppingCartPage)}");
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

 
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private void SubscribeToEvent() 
        {
            Debug.WriteLine("Checking Preferense: Preferences - ShoppingCartProducts");
            if(Preferences.ContainsKey("ShoppingCartProducts"))
                Debug.WriteLine($"IsContain: {Preferences.ContainsKey("ShoppingCartProducts")}");


            MessagingCenter.Unsubscribe<string, ProductInCartInfo>("UpdateShoppingCart", "Add Product");
            MessagingCenter.Subscribe<string, ProductInCartInfo>("UpdateShoppingCart", "Add Product", (sender, args) => {

                List<ProductInCartInfo> productsList = new List<ProductInCartInfo>();
                var jsonProductList = Preferences.Get("ShoppingCartProducts", null);
                if (!string.IsNullOrEmpty(jsonProductList))
                {
                    productsList = JsonConvert.DeserializeObject<List<ProductInCartInfo>>(Preferences.Get("ShoppingCartProducts", null));
                }

                productsList.Add(args);
                Preferences.Set("ShoppingCartProducts", JsonConvert.SerializeObject(productsList));

                #region To be removed in the future
                Debug.WriteLine($"{nameof(this.GetShoppingCartProductsList)} - productList:");
                foreach (var product in productsList)
                {
                    Debug.WriteLine($"{product.ToString()}");
                }

                ProductsCount = productsList.Count();
                Debug.WriteLine($"{nameof(this.GetShoppingCartProductsList)} - Total Products in Cart: {ProductsCount}");
                #endregion
            });
        }

        protected IEnumerable<ProductInCartInfo> GetShoppingCartProductsList() 
        {
            var jsonProductList = Preferences.Get("ShoppingCartProducts", null);
            if (!string.IsNullOrEmpty(jsonProductList)) 
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductInCartInfo>>(jsonProductList);
            }

            return new List<ProductInCartInfo>();
        }

        public virtual void Initialize() 
        {
            var productsList = GetShoppingCartProductsList();
            ProductsCount = productsList.Count();
        }

        public int ProductsCount
        {
            get { return _productsCount; }
            set { SetProperty(ref _productsCount, value); }
        }

    }
}
