using SmartApp.MVVM.Models;
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
        public KitchenViewModel KitchenVM { get; set; }

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
            KitchenViewCommand = new RelayCommand(x => { CurrentView = KitchenVM; });
            KitchenVM = new KitchenViewModel();

            CurrentView = KitchenVM;
        }
    }
}
