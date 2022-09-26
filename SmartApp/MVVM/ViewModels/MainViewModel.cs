using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp.MVVM.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private object _currentView;
        public RelayCommand KitchenViewCommand { get; set; }
        public KitchenViewModel KitchenViewModel { get; set; }
        public RelayCommand BedroomViewCommand { get; set; }
        public BedroomViewModel BedroomViewModel { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            KitchenViewModel = new();
            BedroomViewModel = new();
            KitchenViewCommand = new RelayCommand(x => { CurrentView = KitchenViewModel; });
            BedroomViewCommand = new RelayCommand(x => { CurrentView = BedroomViewModel; });
            CurrentView = KitchenViewModel;

        }
    }
}
