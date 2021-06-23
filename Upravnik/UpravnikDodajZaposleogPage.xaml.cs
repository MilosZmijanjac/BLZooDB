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
    /// Interaction logic for UprvnikDodajZaposleogPage.xaml
    /// </summary>
    public partial class UpravnikDodajZaposleogPage : Page
    {
        public UpravnikDodajZaposleogPage()
        {
            InitializeComponent();
            try
            {
                InitNadredjeniCB();
                InitOdjeljenjeCB();
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom inicijalizacije ComboBox-eva\n"+ex.Message);
            }

        }

        private void InitNadredjeniCB()
        {
            var zaposleni = ZaposleniDAO.GetZaposleniList();
            NadredjeniComboBox.SelectedValuePath = "Zaposleni_id";
            NadredjeniComboBox.DisplayMemberPath = "ImePrezimeProperty";
            NadredjeniComboBox.ItemsSource = zaposleni;
        }

        private void InitOdjeljenjeCB()
        {
            var odjeljenja = OdjeljenjeDAO.GetOdjeljenja();
            OdjeljenjeComboBox.SelectedValuePath = "Odjeljenje_id";
            OdjeljenjeComboBox.DisplayMemberPath = "Odjeljenje_naziv";
            OdjeljenjeComboBox.ItemsSource = odjeljenja;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine(int.Parse(NadredjeniComboBox.SelectedValue.ToString()));
                Console.WriteLine(int.Parse(OdjeljenjeComboBox.SelectedValue.ToString()));
               int id= ZaposleniDAO.DodajZapolsnoeg(LozinkaTextBox.Text, ImeTextBox.Text, PrezimeTextBox.Text,
                    NadredjeniComboBox.SelectedValue as int? ??default(int), OdjeljenjeComboBox.SelectedValue as int? ?? default(int));
                MessageBox.Show("Zaposleni " + id.ToString() + " je uspjesno dodat");
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom dodavanja novog zaposlenog\n" + ex.Message);
            }
        }
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpravnikZaposleniListPage());
        }
    }
}
