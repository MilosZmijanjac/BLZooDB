using BLZooDB.DAO;
using BLZooDB.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for CuvarCuvariZivotinjePage.xaml
    /// </summary>
    public partial class CuvarCuvariZivotinjePage : Page
    {
        int animal_id;
        public CuvarCuvariZivotinjePage(int id)
        {
            ObservableCollection<Zaposleni> cuvari = new ObservableCollection<Zaposleni>();
            animal_id = id;

            InitializeComponent();
            ListViewCuvari.ItemsSource = cuvari;
            try
            {
                foreach (var x in CuvarDAO.GetCuvariOdZivotinje(id))
                    cuvari.Add(x);
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa cuvara \n" + ex.Message);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            int c_id = ((sender as Button).DataContext as Zaposleni).Zaposleni_id;
            try
            {
                CuvarDAO.OduzmiZivotinjuCuvaru(c_id, animal_id);
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom oduzimanja cuvara zivotinji\n" + ex.Message);
            }
            NavigationService.Navigate(new CuvarCuvariZivotinjePage(animal_id));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CuvarDodijeliCuvaraPage());
        }
    }
}
