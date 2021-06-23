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
    /// Interaction logic for CuvarDodijeliCuvaraPage.xaml
    /// </summary>
    public partial class CuvarDodijeliCuvaraPage : Page
    {
        public CuvarDodijeliCuvaraPage()
        {
            ObservableCollection<Zivotinja> animals = new ObservableCollection<Zivotinja>();

            InitializeComponent();
            ListViewZivotinje.ItemsSource = animals;
            try
            {
                foreach (var x in ZivotinjaDAO.GetZivotinje())
                    animals.Add(x);
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa zivotinja\n" + ex.Message);
            }
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            Zivotinja z = (sender as Button).DataContext as Zivotinja;

            NavigationService.Navigate(new CuvarCuvariZaDodjeluPage(z.Zivotinja_id));
        }

        private void See_Click(object sender, RoutedEventArgs e)
        {
            Zivotinja z = (sender as Button).DataContext as Zivotinja;

            NavigationService.Navigate(new CuvarCuvariZivotinjePage(z.Zivotinja_id));
        }
    }
}
