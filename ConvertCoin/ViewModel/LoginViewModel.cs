using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace  ConvertCoin.ViewModel;

/*

*/

public partial class LoginViewModel : ObservableObject
{
    // Stores the username entered by the user
    [ObservableProperty]
    string username;

// Stores the password entered by the user
    [ObservableProperty]
    string password;

    // Command to be executed when the login button is clicked
        public IAsyncRelayCommand LoginCommand { get; }

    

    [RelayCommand]
    void Login(){

        //login TODO

    }
    [RelayCommand]
    void ForgotPassword() {

        //forget password

    }
}
