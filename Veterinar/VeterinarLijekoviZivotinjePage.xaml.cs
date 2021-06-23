using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarLijekoviZivotinjePage.xaml
    /// </summary>
    public partial class VeterinarLijekoviZivotinjePage : Page
    {
        int zivotinja_id;
        public VeterinarLijekoviZivotinjePage(int id)
        {
            InitializeComponent();
            zivotinja_id = id;
            try
            {
                LijekoviZivotinjeDataGrid.ItemsSource = LijekDAO.GetLijekoviZivotinjeDataTable(id).DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa lijekova zivotinje\n" + ex.Message);
            }
        }
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VeterinarLijekoviListaPage(zivotinja_id));
        }
    }
}
