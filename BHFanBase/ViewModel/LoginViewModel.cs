
using BHFanBase.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BHFanBase.ViewModel
{
    public class LoginInput: ObservableObject
    {
        public string username {get; set;}
        public string password { get; set; }
    }

    public class LoginViewModel: ViewModelBase
    {
        public RelayCommand<LoginInput> LoginCommand { get; set; }
        public LoginInput InputParams { get; set; }
        private IBHNavigationService _navigationService;

        public LoginViewModel(IDataService dataService, IBHNavigationService bHNavigationService)
        {
            InputParams = new LoginInput { username = "", password = "" };
            LoginCommand = new RelayCommand<LoginInput>(login, (LoginInput a) => true);
            _navigationService = bHNavigationService;
        }

        private void login(LoginInput arg)
        {
            if (arg.username.Equals("admin") && arg.password.Equals("admin"))
            {
                _navigationService.NavigateTo("Main");
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }
    }

    public class LoginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new LoginInput{ username = values[0] as string, password = values[1] as string };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
