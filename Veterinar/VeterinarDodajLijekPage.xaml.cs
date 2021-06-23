using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarDodajLijekPage.xaml
    /// </summary>
    public partial class VeterinarDodajLijekPage : Page
    {
        public VeterinarDodajLijekPage()
        {
            InitializeComponent();
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(KolicinaTextBox.Text, out int kol) && int.TryParse(PotrebnaKolicinaBox.Text, out int pot))
                try
                {
                    LijekDAO.InsertLijek(ImeTextbox.Text, kol, pot);
                    MessageBox.Show("Lijek je unesen");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska prilikom unosa lijeka\n" + ex.Message);
                }
            else
                MessageBox.Show("Vrijednosti nisu validne");
        }
    }
}
