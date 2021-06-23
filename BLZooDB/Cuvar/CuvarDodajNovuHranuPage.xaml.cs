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
    /// Interaction logic for CuvarDodajNovuHranuPage.xaml
    /// </summary>
    public partial class CuvarDodajNovuHranuPage : Page
    {
        public CuvarDodajNovuHranuPage()
        {
            InitializeComponent();
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(KolicinaTextBox.Text, out int kol) && int.TryParse(PotrebnaKolicinaBox.Text, out int pot))
                try
                {
                    HranaDAO.InsertHrana(ImeTextbox.Text, kol, pot);
                    MessageBox.Show("Hrana je unesena");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska prilikom unosa hrane\n" + ex.Message);
                }
            else
                MessageBox.Show("Vrijednosti nisu validne");
        }
    }
}
