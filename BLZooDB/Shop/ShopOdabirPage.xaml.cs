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

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for ShopOdabirPage.xaml
    /// </summary>
    public partial class ShopOdabirPage : Page
    {
        int flag;
        public ShopOdabirPage(int tick)
        {
            InitializeComponent();
            flag = tick;
        }

        private void Karte_Click(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case 0:
                    NavigationService.Navigate(new ShopProizvodiPage(true));
                    break;
                case 1:
                    NavigationService.Navigate(new ShopInventarPage(true));
                    break;
                case 2:
                    NavigationService.Navigate(new ShopDodajProizvodPage(true));
                    break;
            }
          
        }

        private void Proizvodi_Click(object sender, RoutedEventArgs e)
        {
            switch (flag)
            {
                case 0:
                    NavigationService.Navigate(new ShopProizvodiPage(false));
                    break;
                case 1:
                    NavigationService.Navigate(new ShopInventarPage(false));
                    break;
                case 2:
                    NavigationService.Navigate(new ShopDodajProizvodPage(false));
                    break;
            }
        }
    }
}
