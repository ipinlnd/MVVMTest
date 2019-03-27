using GalaSoft.MvvmLight;
using BHFanBase.Model;
using GalaSoft.MvvmLight.Messaging;

namespace BHFanBase.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string GeneralWelcome;

        private string _welcomeTitle = string.Empty;

        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }
        
        public MainViewModel(IDataService dataService, IBHNavigationService bHNavigation)
        {
            GeneralWelcome = "";
            Messenger.Default.Register<string>(this, message =>
            {
                WelcomeTitle = GeneralWelcome + " " + message;
            });
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        return;
                    }

                    WelcomeTitle = item.Title;
                    GeneralWelcome = item.Title;
                });
        }
    }
}