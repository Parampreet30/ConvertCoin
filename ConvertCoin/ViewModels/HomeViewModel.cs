

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

         public IAsyncRelayCommand GetRateCommand { get;}

         public HomeViewModel(){
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
            Console.WriteLine("Could not start MAUI: ");
            
            /*var partsCollection = await ExchangeApi.GetRate();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                var p = partsCollection;
            });
            */
        
        }
        [RelayCommand]
        void Country() { }

        [RelayCommand]
        void CovertedCountries() { }


    }
}
