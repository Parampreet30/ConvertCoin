using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace  ConvertCoin.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    string username;


    [ObservableProperty]
    string password;

    [RelayCommand]
    void Login(){

        //login TODO

    }
    [RelayCommand]
    void ForgotPassword() {

        //forget password

    }
}
