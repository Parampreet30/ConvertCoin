using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ConvertCoin.ViewModels
{
    public partial class HomeViewModel1: ObservableRecipient
    {
        /*
       amount: this will have the currency of the country that is to be converted
       convertedAmount: this will be the converted currency of the desired country
       amountSelectedCountry: this will have the country code of the country that is to be converted
      convertedAmountCountry: this will be the desired country for which the currency is being converted  

       */

        public IAsyncRelayCommand GetRateCommand { get; }

        public HomeViewModel1()
        {
            GetRateCommand = new AsyncRelayCommand(SwitchCountries);
        }

        [ObservableProperty]
        double amount;
        [ObservableProperty]
        double convertedAmount;
        [ObservableProperty]
        string amountSelectedCountry;
        [ObservableProperty]
        string convertedAmountCountry;

        [RelayCommand]
        async Task SwitchCountries()
        {
            Debug.WriteLine("SwitchCountries method called");
            var partsCollection = await ExchangeApi.GetRate();
            Debug.WriteLine( partsCollection);
            decimal cr = partsCollection.conversion_rates["CAD"];
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Debug.WriteLine(partsCollection.conversion_rates["CAD"]);
                Debug.WriteLine("Updating UI with the exchange rate data");
                // Do something with partsCollection, for example:
                //if (partsCollection != null && partsCollection.Any())
                //{
                    // Assuming partsCollection contains exchange rates
                    // Update your properties here based on partsCollection data
                    //ConvertedAmount = partsCollection.First().Rate * Amount;
                 //Debug.WriteLine( partsCollection);

                //}
                //else
                //{
                  //  Debug.WriteLine("Failed to get exchange rate data");
                //}
            });
        }
        [RelayCommand]
        void Country() { }

        [RelayCommand]
        void CovertedCountries() { }


    }
}

