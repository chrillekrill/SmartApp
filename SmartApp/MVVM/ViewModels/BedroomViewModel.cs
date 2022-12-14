using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp.MVVM.ViewModels
{
    internal class BedroomViewModel
    {
        public string Title { get; set; } = "Bedroom";
        public string Temperature { get; set; } = "20";
        public string TemperatureScale { get; set; } = "°C";
        public string Humidity { get; set; } = "39";
        public string HumidityScale { get; set; } = "%";
    }
}
