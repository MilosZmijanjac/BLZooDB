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
using BLZooDB.DAO;
using BLZooDB.Model;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for ShopNarudzbaPage.xaml
    /// </summary>
    public partial class ShopNarudzbaPage : Page
    {
        Proizvod proizvod;
        int kolicina;
        public ShopNarudzbaPage(Proizvod p, int kolicina)
        {
            InitializeComponent();
            proizvod = p;
            this.kolicina = kolicina;
            ProizvodID.Content = p.ProizvodId.ToString();
            UkupnaCijena.Content = (p.Cijena * kolicina).ToString();
            Kolicina.Content = kolicina.ToString();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NarudzbaDAO.InsertNarudzbu(proizvod.ProizvodId, DateTime.UtcNow, proizvod.Cijena * kolicina, kolicina, Email.Text, proizvod.Velicina, "poslato", Adresa.Text, Grad.Text, Drzava.Text, PostanskiBroj.Text);
                ProizvodDAO.UpdateProizvodi(proizvod.ProizvodId, proizvod.Velicina, kolicina * (-1));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom generisanja narudzbe " + ex.Message);
            }
            MessageBox.Show("Uspjesno");
            NavigationService.GoBack();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
