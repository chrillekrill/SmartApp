using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartApp.Components
{
    /// <summary>
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        public Tile()
        {
            InitializeComponent();
        }

        public static DependencyProperty TitleProperty
         = DependencyProperty.Register("Title", typeof(string), typeof(Tile));
        public string Title { 
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

     

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static DependencyProperty IsCheckedProperty
            = DependencyProperty.Register("IsChecked", typeof(bool), typeof(Tile));


        public string ActiveIcon
        {
            get { return (string)GetValue(ActiveIconProperty); }
            set { SetValue(ActiveIconProperty, value); }
        }

        public static DependencyProperty ActiveIconProperty
            = DependencyProperty.Register("activeIcon", typeof(string), typeof(Tile));

        public string InActiveIcon
        {
            get { return (string)GetValue(InActiveIconProperty); }
            set { SetValue(InActiveIconProperty, value); }
        }

        public static DependencyProperty InActiveIconProperty
            = DependencyProperty.Register("InActiveIcon", typeof(string), typeof(Tile));

        private void toggle_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
