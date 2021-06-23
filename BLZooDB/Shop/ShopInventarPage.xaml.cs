using BLZooDB.DAO;
using BLZooDB.Model;
using System;
using System.Collections;
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
    /// Interaction logic for ShopInventarPage.xaml
    /// </summary>
    public partial class ShopInventarPage : Page
    {
        bool Tickets;
        public ShopInventarPage(bool Tick)
        {
            InitializeComponent();
            Tickets = Tick;
            ArrayList products;
            try
            {
                if (!Tickets)
                    products = ProizvodDAO.GetProizvodi();
                else
                    products = ProizvodDAO.GetUlaznice();
                if (products.Count > 0)
                    ListViewProducts.ItemsSource = products;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom prikaza artikala" + ex.Message);
            }
        }
        private void Click_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine(((sender as Button).DataContext as Proizvod).Naziv);
                Console.WriteLine(((sender as Button).Parent as StackPanel).Children.OfType<Grid>().First().Children.OfType<TextBox>().First().Text);

                ProizvodDAO.UpdateProizvodi(((sender as Button).DataContext as Proizvod).ProizvodId, ((sender as Button).DataContext as Proizvod).Velicina,
                    int.Parse(((sender as Button).Parent as StackPanel).Children.OfType<Grid>().First().Children.OfType<TextBox>().First().Text));
                if (!Tickets)
                    ListViewProducts.ItemsSource = ProizvodDAO.GetProizvodi();
                else
                    ListViewProducts.ItemsSource = ProizvodDAO.GetUlaznice();
            } catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom azuriranja inventara " + ex.Message);
            }
            MessageBox.Show("Azurirano");
        }
    }
}
