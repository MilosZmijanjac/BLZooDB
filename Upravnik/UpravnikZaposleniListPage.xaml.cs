using BLZooDB.DAO;
using BLZooDB.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for UpravnikZaposleniListPage.xaml
    /// </summary>
    public partial class UpravnikZaposleniListPage : Page
    { 
        public UpravnikZaposleniListPage()
        {
            ObservableCollection<Zaposleni> zaposleni = new ObservableCollection<Zaposleni>();
            InitializeComponent();
            ListViewZaposleni.ItemsSource = zaposleni;
            try
            {
                foreach (var x in ZaposleniDAO.GetZaposleniList())
                    zaposleni.Add(x);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom generisanja liste zaposlenih" + "\n" + ex.Message);
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var id = ((sender as Button).DataContext as Zaposleni).Zaposleni_id;
            
           try
            {
                ZaposleniDAO.ObrisiZaposlenog(id);
                MessageBox.Show("Zaposleni uspjesno obrisan");
                
               NavigationService.Navigate(new UpravnikZaposleniListPage());
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom brisanja zaposlenog\n" + ex.Message);
            }

        }
        private void Dodaj_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new UpravnikDodajZaposleogPage());
        }
    }
}
