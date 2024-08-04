

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace ConvertCoin.ViewModel
{
    public partial class HomeViewModel : ObservableRecipient
    {
        /*
         amount: this will have the currency of the country that is to be converted
         convertedAmount: this will be the converted currency of the desired country
         amountSelectedCountry: this will have the country code of the country that is to be converted
        convertedAmountCountry: this will be the desired country for which the currency is being converted  
        
         */

        public IAsyncRelayCommand GetRateCommand { get; set; }

        public HomeViewModel()
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

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Debug.WriteLine("Updating UI with the exchange rate data");
                // Do something with partsCollection, for example:
                if (partsCollection != null && partsCollection.Any())
                {
                    // Assuming partsCollection contains exchange rates
                    // Update your properties here based on partsCollection data
                    //ConvertedAmount = partsCollection.First().Rate * Amount;
                }
                else
                {
                    Debug.WriteLine("Failed to get exchange rate data");
                }
            });
        }
        [RelayCommand]
        void Country() { }

        [RelayCommand]
        void CovertedCountries() { }


    }
}
