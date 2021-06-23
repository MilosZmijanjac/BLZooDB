using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarPropisujeLijekPage.xaml
    /// </summary>
    public partial class VeterinarPropisujeLijekPage : Page
    {
        int lijek_id;
        int zivotinja_id;
        string lijek_naziv;
        public VeterinarPropisujeLijekPage(int l_id, string l_ime, int z_id)
        {
            InitializeComponent();
            lijek_id = l_id;
            lijek_naziv = l_ime;
            zivotinja_id = z_id;

            NazivLabel.Content = l_ime;
            IdLabel.Content = l_id.ToString();
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {if (int.TryParse(DozatBox.Text, out int doza) && int.TryParse(TerapijaTextBox.Text, out int ter) && ter < 1000 && doza < 10000)
                try
                {
                    LijekDAO.PropisiLijek(zivotinja_id, lijek_id, doza, VelicinaComboBox.Text, ter, BolestTextBox.Text);
                    MessageBox.Show("Lijek je propisan");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska prilikom propisivanja lijeka\n" + ex.Message);
                }
            else
                MessageBox.Show("Unjeti podaci nisu validni\n");
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
