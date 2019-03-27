using BHFanBase.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BHFanBase.ViewModel
{
    public class MenuItem
    {
        public string title { get; set; }
    }
    public class SideMenuViewModel : ViewModelBase
    {
        public List<MenuItem> ListBoxItems { get; set; }
        public RelayCommand<MenuItem> menuItemChanged { get; set; }
        public MenuItem SelectedItem { get; set; }

        public SideMenuViewModel(IDataService dataService, IBHNavigationService bHNavigation)
        {
            menuItemChanged = new RelayCommand<MenuItem>(changed, (MenuItem e) => true);
            ListBoxItems = new List<MenuItem>();
            ListBoxItems.Add(new MenuItem { title = "Main Page" });
            ListBoxItems.Add(new MenuItem { title = "Profile" });
            ListBoxItems.Add(new MenuItem { title = "Settings" });
            Messenger.Default.Send("Main Page");
        }

        private void changed(MenuItem e)
        {
            Messenger.Default.Send(e.title);
        }
    }
}
