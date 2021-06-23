using BLZooDB.DAO;
using BLZooDB.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for CuvarUrediHranu.xaml
    /// </summary>
    public partial class CuvarUrediHranu : Page
    {
        public CuvarUrediHranu()
        {
            ObservableCollection<Hrana> hrana = new ObservableCollection<Hrana>();
            InitializeComponent();
            try
            {
                hrana = HranaDAO.GetHrana();

            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa hrane\n" + ex.Message);
            }
                ListViewProducts.ItemsSource = hrana;
            
        }

        private void Click_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HranaDAO.UpdateHrana(((sender as Button).DataContext as Hrana).Hrana_id,
                    int.Parse(((sender as Button).Parent as StackPanel).Children.OfType<Grid>().First().Children.OfType<TextBox>().First().Text));
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom azuriranja hrane\n" + ex.Message);
            }
            NavigationService.Navigate(new CuvarUrediHranu());
        }

        private void DodajNovuHranu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CuvarDodajNovuHranuPage());
        }
    }
}
