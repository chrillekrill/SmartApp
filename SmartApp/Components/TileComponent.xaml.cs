using Microsoft.Azure.Devices;
using Newtonsoft.Json;
using SmartApp.MVVM;
using SmartApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;

namespace SmartApp.Components
{
    /// <summary>
    /// Interaction logic for TileComponent.xaml
    /// </summary>
    public partial class TileComponent : UserControl, INotifyPropertyChanged
    {
        private readonly RegistryManager registryManager = RegistryManager.CreateFromConnectionString("HostName=iothubv74.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=7MWoKQE1RIODQmLaQTxtbH2bCU45zNsy0DhBx7Rs1nM=");

        public TileComponent()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static readonly DependencyProperty DeviceIdProperty = DependencyProperty.Register("DeviceId", typeof(string), typeof(TileComponent));
        public string DeviceId
        {
            get { return (string)GetValue(DeviceIdProperty); }
            set { SetValue(DeviceIdProperty, value); }
        }

        public static readonly DependencyProperty DeviceNameProperty = DependencyProperty.Register("DeviceName", typeof(string), typeof(TileComponent));
        public string DeviceName
        {
            get { return (string)GetValue(DeviceNameProperty); }
            set { SetValue(DeviceNameProperty, value); }
        }
        public static readonly DependencyProperty DeviceTypeProperty = DependencyProperty.Register("DeviceType", typeof(string), typeof(TileComponent));
        public string DeviceType
        {
            get { return (string)GetValue(DeviceTypeProperty); }
            set { SetValue(DeviceTypeProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(TileComponent));
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }


        public static readonly DependencyProperty IconActiveProperty = DependencyProperty.Register("IconActive", typeof(string), typeof(TileComponent));

        public string IconActive
        {
            get { return (string)GetValue(IconActiveProperty); }
            set { SetValue(IconActiveProperty, value); }
        }

        public static readonly DependencyProperty IconInActiveProperty = DependencyProperty.Register("IconInActive", typeof(string), typeof(TileComponent));

        public string IconInActive
        {
            get { return (string)GetValue(IconInActiveProperty); }
            set { SetValue(IconInActiveProperty, value); }
        }

        private bool _deviceState;

        public bool DeviceState
        {
            get { return _deviceState; }
            set
            {
                _deviceState = value;
                OnPropertyChanged();
            }
        }

        private async void removeDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var deviceItem = (DeviceItem)button!.DataContext;


                using ServiceClient serviceClient = ServiceClient.CreateFromConnectionString("HostName=iothubv74.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=7MWoKQE1RIODQmLaQTxtbH2bCU45zNsy0DhBx7Rs1nM=");

                var directMethod = new CloudToDeviceMethod("RemoveDevice");
                var result = await serviceClient.InvokeDeviceMethodAsync(deviceItem.DeviceId, directMethod);
                if(result.Status == 200)
                {
                    await registryManager.RemoveDeviceAsync(deviceItem.DeviceId);
                    deviceNameStyle.FontSize = 10;
                    DeviceName = "Removing device please wait...";
                    DeviceType = "";
                    removeDevice.Content = "Removed";
                    OnPropertyChanged();
                } else
                {
                    var error = result.GetPayloadAsJson();
                    var errorMsg = error;
                }
            }
            catch { }
        }

        private async void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var deviceItem = (DeviceItem)toggleButton!.DataContext;

                using ServiceClient serviceClient = ServiceClient.CreateFromConnectionString("HostName=iothubv74.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=7MWoKQE1RIODQmLaQTxtbH2bCU45zNsy0DhBx7Rs1nM=");
                var directMethod = new CloudToDeviceMethod("ChangeDeviceState");
                var result = await serviceClient.InvokeDeviceMethodAsync(deviceItem.DeviceId, directMethod);
                var resultText = result.GetPayloadAsJson();
       
            } catch { }
        }
    }
}
