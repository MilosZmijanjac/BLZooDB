using BLZooDB.DAO;
using BLZooDB.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarAzuriraZivotinjuPage.xaml
    /// </summary>
    public partial class VeterinarAzuriraZivotinjuPage : Page
    {
        Zivotinja zivotinja;
        bool inEdit = false;
        public VeterinarAzuriraZivotinjuPage(Zivotinja z)
        {
            InitializeComponent();
            zivotinja = z;
            ImeTextBox.Text = z.Ime;
            VrstaTextBox.Text = z.Zivotinja_vrsta;
            DatumRTextBox.Text = z.Datum_rodjenja.Date.ToString();
            PolTextBox.Text = z.Spol;
            IshranaTextBox.Text = z.Tip_ishrane;
            SmjestajTextBox.Text = z.Smjestaj_id.ToString();
            StanjeComboBox.Text = z.Zdravstveno_stanje;
            BrojHranjenjaTextBox.Text = z.Broj_hranjenja_dnevno.ToString();
        }
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VeterinarHomePage());
        }

        private void Uredi_Click(object sender, RoutedEventArgs e)
        {
            inEdit = !inEdit;
            if (!inEdit)
            {
                StanjeComboBox.IsEnabled = true;
                BrojHranjenjaTextBox.IsEnabled = true;
                Uredi.Content = "Sacuvaj";
            }
            else
            {
                StanjeComboBox.IsEnabled = false;
                BrojHranjenjaTextBox.IsEnabled = false;
                Uredi.Content = "Uredi";
                if (StanjeComboBox.Text.Equals(zivotinja.Zdravstveno_stanje) && BrojHranjenjaTextBox.Text.Equals(zivotinja.Broj_hranjenja_dnevno.ToString()))
                    return;
                else if(int.TryParse(BrojHranjenjaTextBox.Text, out int broj)&&broj<1000)
                {
                    zivotinja.Zdravstveno_stanje = StanjeComboBox.Text;

                    zivotinja.Broj_hranjenja_dnevno = broj;
                    try
                    {
                        ZivotinjaDAO.UpdateZivotinja(zivotinja.Zivotinja_id, zivotinja.Zdravstveno_stanje, zivotinja.Broj_hranjenja_dnevno);
                    } catch (Exception ex)
                    {
                        MessageBox.Show("Greska prilikom azuriranja zivotinje\n" + ex.Message);
                    }
                }
                else { MessageBox.Show("Greska prilikom azuriranja zivotinje\n"); return; }
            }


        }

        private void Hrana_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VeterinarHranaZivotinjePage(zivotinja.Zivotinja_id));
        }

        private void Lijek_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VeterinarLijekoviZivotinjePage(zivotinja.Zivotinja_id));
        }
    }
}
