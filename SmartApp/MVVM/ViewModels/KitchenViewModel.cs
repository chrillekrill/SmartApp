using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;
using SmartApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SmartApp.MVVM.ViewModels
{
    internal class KitchenViewModel : ObservableObject
    {
        private DispatcherTimer timer;
        private ObservableCollection<DeviceItem> _deviceItems;
        private List<DeviceItem> _tempList;
        private readonly RegistryManager registryManager = RegistryManager.CreateFromConnectionString("HostName=iothubv73.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=QkPsCR+vmNjexd1ggpjtGzppwC+Udq0LymJL3jgUxIQ=");

        public KitchenViewModel()
        {
            _tempList = new List<DeviceItem>();
            _deviceItems = new ObservableCollection<DeviceItem>();
            PopulateDeviceItemsAsync().ConfigureAwait(false);
            updateTemperature().ConfigureAwait(false);
            SetInterval(TimeSpan.FromSeconds(20));
            
        }


        public string Title { get; set; } = "Kitchen";

        private string _temperature;
        public string Temperature
        {
            get => _temperature!;
            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }
        public string Humidity { get; set; } = "34 %";
        public IEnumerable<DeviceItem> DeviceItems => _deviceItems;



        private void SetInterval(TimeSpan interval)
        {
            timer = new DispatcherTimer()
            {
                Interval = interval
            };

            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }

        private async void timer_tick(object sender, EventArgs e)
        {
            await updateTemperature();
            await PopulateDeviceItemsAsync();
            await UpdateDeviceItemsAsync();     
        }

        private async Task updateTemperature()
        {
            var result = registryManager.CreateQuery("SELECT * FROM devices WHERE properties.reported.location = 'kitchen'");
            if (result.HasMoreResults)
            {
                foreach (Twin twin in await result.GetNextAsTwinAsync())
                {
                    var t = await registryManager.GetTwinAsync(twin.DeviceId);

                    try
                    {
                        int temp = (int)t.Properties.Reported["temperature"];
                        Temperature = $"{temp} °C";
                    }
                    catch { }
                }
            }
        }

        private async Task UpdateDeviceItemsAsync()
        {
            _tempList.Clear();

            foreach (var item in _deviceItems)
            {
                var device = await registryManager.GetDeviceAsync(item.DeviceId);
                if (device == null)
                    _tempList.Add(item);
            }

            foreach (var item in _tempList)
            {
                _deviceItems.Remove(item);
            }
        }

        private async Task PopulateDeviceItemsAsync()
        {
            //var result = registryManager.CreateQuery("select * from devices where location = 'kitchen'");
            var result = registryManager.CreateQuery("select * from devices where properties.reported.location = 'kitchen'");

            if (result.HasMoreResults)
            {
                foreach (Twin twin in await result.GetNextAsTwinAsync())
                {
                    var device = _deviceItems.FirstOrDefault(x => x.DeviceId == twin.DeviceId);

                    if (device == null)
                    {
                        device = new DeviceItem
                        {
                            DeviceId = twin.DeviceId,
                        };

                        try { device.DeviceName = twin.Properties.Reported["deviceName"]; }
                        catch { device.DeviceName = device.DeviceId; }
                        try { device.DeviceType = twin.Properties.Reported["deviceType"]; }
                        catch { }

                        switch (device.DeviceType.ToLower())
                        {
                            case "fan":
                                device.IconActive = "\uf863";
                                device.IconInActive = "\uf863";
                                device.StateActive = "ON";
                                device.StateInActive = "OFF";
                                break;

                            case "light":
                                device.IconActive = "\uf672";
                                device.IconInActive = "\uf0eb";
                                device.StateActive = "ON";
                                device.StateInActive = "OFF";
                                break;
                            case "thermometer":
                                device.IconActive = "\uf2c8";
                                device.IconInActive = "\uf2cb";
                                device.StateActive = "DISABLE";
                                device.StateInActive = "ENABLE";
                                break;
                            default:
                                device.IconActive = "\uf2db";
                                device.IconInActive = "\uf2db";
                                device.StateActive = "ENABLE";
                                device.StateInActive = "DISABLE";
                                break;
                        }

                        _deviceItems.Add(device);
                    }
                    else { }
                }
            }
            else
            {
                _deviceItems.Clear();
            }
        }
    }
}
