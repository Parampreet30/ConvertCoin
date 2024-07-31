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

    public LoginViewModel()
        {
            // Initializes the login command with the LoginAsync method
            LoginCommand = new AsyncRelayCommand(LoginAsync);
        }

        // Asynchronously handles the login process
        private async Task LoginAsync()
        {
            // TODO: Implement login logic here
            // - Validate user credentials
            // - Call authentication service
            // - Handle successful login (e.g., navigate to main page)
            // - Handle failed login (e.g., display error message)
        }
    [RelayCommand]
    void ForgotPassword() {
        //forget password
    }
}
