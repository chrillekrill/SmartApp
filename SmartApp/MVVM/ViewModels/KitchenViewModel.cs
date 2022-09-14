using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApp.MVVM.ViewModels
{
    internal class KitchenViewModel
    {
        public string Title { get; set; } = "Kitchen and dining";
        public string Temperature { get; set; } = "24";
        public string Humidity { get; set; } = "33";
    }
}
