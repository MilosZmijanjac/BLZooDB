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
    /// Interaction logic for CuvarCuvariZaDodjeluPage.xaml
    /// </summary>
    public partial class CuvarCuvariZaDodjeluPage : Page
    {
        int animal_id;
        public CuvarCuvariZaDodjeluPage(int id)
        {
            ObservableCollection<Zaposleni> cuvari = new ObservableCollection<Zaposleni>();
            animal_id = id;

            InitializeComponent();
            ListViewCuvari.ItemsSource = cuvari;
            try
            {
                foreach (var x in CuvarDAO.GetFreeCuvari(id))
                    cuvari.Add(x);
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa cuvara\n" + ex.Message);
            }
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            int c_id = ((sender as Button).DataContext as Zaposleni).Zaposleni_id;
            try
            {
                CuvarDAO.DodijeliZivotinjuCuvaru(c_id, animal_id);
            } catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom dodijele cuvara\n" + ex.Message);
            }
            NavigationService.Navigate(new CuvarDodijeliCuvaraPage());

        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
