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
    /// Interaction logic for VeterinarHomePage.xaml
    /// </summary>
    public partial class VeterinarHomePage : Page
    {
        public VeterinarHomePage()
        {
            ObservableCollection<Zivotinja> animals = new ObservableCollection<Zivotinja>();

            InitializeComponent();
            ListViewZivotinje.ItemsSource = animals;
            try
            {
                foreach (var x in ZivotinjaDAO.GetZivotinje())
                    animals.Add(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gresko prilikom ispisa zivotinja" + "\n" + ex.Message);
            }
        }


        private void Select_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VeterinarAzuriraZivotinjuPage((sender as Button).DataContext as Zivotinja));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ZivotinjaDAO.DeleteZivotinja(((sender as Button).DataContext as Zivotinja).Zivotinja_id);
            }catch(Exception ex)
            {
                MessageBox.Show("Gresko prilikom uklanjanja zivotinje"+"\n"+ex.Message);
            }

            MessageBox.Show("Zivotinja je uklonjena");
            NavigationService.Navigate(new VeterinarHomePage());
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VeterinarDodajZivotinjuPage());
        }
    }
}
