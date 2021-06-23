using BLZooDB.DAO;
using BLZooDB.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarLijekoviListaPage.xaml
    /// </summary>
    public partial class VeterinarLijekoviListaPage : Page
    {
        int zivotinja_id;
        public VeterinarLijekoviListaPage(int id)
        {
            InitializeComponent();
            zivotinja_id = id;
            try
            {
                ListViewMedicine.ItemsSource = LijekDAO.GetLijekovi();
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa lijekova koji se mogu propisati\n" + ex.Message);
            }
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            int lijek_id = ((sender as Button).DataContext as Lijek).Lijek_id;
            string lijek_naziv = ((sender as Button).DataContext as Lijek).Lijek_naziv;
            NavigationService.Navigate(new VeterinarPropisujeLijekPage(lijek_id, lijek_naziv, zivotinja_id));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
