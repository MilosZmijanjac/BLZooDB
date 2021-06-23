using BLZooDB.DAO;
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
    /// Interaction logic for ShopDodajProizvodPage.xaml
    /// </summary>
    public partial class ShopDodajProizvodPage : Page
    {
        bool flag;
        public ShopDodajProizvodPage(bool isTicket)
        {
            InitializeComponent();
            flag = isTicket;
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (flag)
                    ProizvodDAO.DodajProizvod(NazivTextBox.Text, VelicinaComboBox.Text, int.Parse(KolicinaTextBox.Text), int.Parse(PotrebnaKolicinaTextBox.Text),
                        SlikaTextBox.Text, "karta", 11, decimal.Parse(CijenaTextBox.Text));
                else
                    ProizvodDAO.DodajProizvod(NazivTextBox.Text, VelicinaComboBox.Text, int.Parse(KolicinaTextBox.Text), int.Parse(PotrebnaKolicinaTextBox.Text),
                    SlikaTextBox.Text, "proizvod", 7, decimal.Parse(CijenaTextBox.Text));
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom dodavanja proizvoda" + ex.Message);
            }
            MessageBox.Show("Proizvod dodat");
        }
    }
}
