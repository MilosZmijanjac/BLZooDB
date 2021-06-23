using BLZooDB.DAO;
using BLZooDB.Model;
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
    /// Interaction logic for ShopProizvodiPage.xaml
    /// </summary>
    public partial class ShopProizvodiPage : Page
    {
        bool isTicket;
        public ShopProizvodiPage(bool Tickets)
        {
            InitializeComponent();
            isTicket = Tickets;
            try
            {
                if (!isTicket)
                {
                    var products = ProizvodDAO.GetProizvodi();
                    if (products.Count > 0)
                        ListViewProducts.ItemsSource = products;
                }
                else
                {
                    var products = ProizvodDAO.GetUlaznice();
                    if (products.Count > 0)
                        ListViewProducts.ItemsSource = products;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom prikaza artikala " + ex.Message);
            }
        }
        private void Click_Click(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new ShopNarudzbaPage(((sender as Button).DataContext as Proizvod),
                int.Parse(((sender as Button).Parent as StackPanel).Children.OfType<Grid>().First().Children.OfType<TextBox>().First().Text)));
            
            try
            {
                if (isTicket)
                    ListViewProducts.ItemsSource = ProizvodDAO.GetUlaznice();
                else
                    ListViewProducts.ItemsSource = ProizvodDAO.GetProizvodi();
            }catch(Exception ex)
            {
                MessageBox.Show("Greska " + ex.Message);
            }
        }
    }
}
