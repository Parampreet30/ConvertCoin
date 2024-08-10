using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ConvertCoin.ViewModels
{
    public partial class HomeViewModel1 : ObservableRecipient
    {
        /*
       amount: this will have the currency of the country that is to be converted
       convertedAmount: this will be the converted currency of the desired country
       amountSelectedCountry: this will have the country code of the country that is to be converted
      convertedAmountCountry: this will be the desired country for which the currency is being converted  

       */

        public IAsyncRelayCommand GetRateCommand { get; }
        [ObservableProperty]
        private string convertedAmount;

        public HomeViewModel1()
        {

            GetRateCommand = new AsyncRelayCommand(SwitchCountries);
            Items = new ObservableCollection<string>
            {
                "CAD",
                "INR"
            };
            string Result;
            double Amount;
        }

        [ObservableProperty]
        private ObservableCollection<string> items;

        [ObservableProperty]
        decimal amount;

        [ObservableProperty]
        string amountSelectedCountry;
        [ObservableProperty]
        string convertedAmountCountry;

        [RelayCommand]
        async Task SwitchCountries()
        {

            Debug.WriteLine("SwitchCountries method called");

            // Check if selectedItem or targetSelectedItem are null
            if (string.IsNullOrEmpty(selectedItem) || string.IsNullOrEmpty(targetSelectedItem))
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // Display an error message
                    ConvertedAmount = "Error: Please select both source and target currencies.";
                });
                return;
            }

            try
            {
                // Fetch exchange rates
                var exchangeRates = await ExchangeApi.GetRate(selectedItem);
                Debug.WriteLine(exchangeRates);

                // Update the UI on the main thread
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Debug.WriteLine(exchangeRates.conversion_rates["CAD"]);
                    Debug.WriteLine("Updating UI with the exchange rate data");

                    // Calculate and display the converted amount
                    Result = (100 * exchangeRates.conversion_rates[selectedItem]).ToString();
                    Result = (amount * exchangeRates.conversion_rates[targetSelectedItem]).ToString();
                    ConvertedAmount = $"{amount} INR = {Result} {targetSelectedItem}";
                });
            }
            catch (Exception ex)
            {
                // Handle any errors during the API call or conversion
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ConvertedAmount = $"Error: {ex.Message}";
                });
            }
        }
        [RelayCommand]
        void Country() { }

        [RelayCommand]
        void CovertedCountries() { }

        [ObservableProperty]
        public string selectedItem;

        [ObservableProperty]
        public string targetSelectedItem;

        [ObservableProperty]
        public string result;




    }
}

