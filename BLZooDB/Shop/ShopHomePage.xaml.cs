using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for ShopHomePage.xaml
    /// </summary>
    public partial class ShopHomePage : Page
    {
        public ShopHomePage()
        {
            InitializeComponent();
        }
        private void IzracunajPrihod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrihodLabel.Content = "Ukupan prihod je: " + (NarudzbaDAO.GetUkupanPrihodOdDo(OdDatePicker.SelectedDate, DoDatePicker.SelectedDate));
            }catch(Exception ex)
            {
                MessageBox.Show("Greska pri racunjanju prihoda\n" + ex.Message);
            }

        }
        private void IzracunajProizvode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProizvodiGrid.ItemsSource = NarudzbaDAO.GetProdaniProizvodiOdDo(OdDatePicker2.SelectedDate, DoDatePicker2.SelectedDate).DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska pri ispisu proizvoda\n" + ex.Message);
            }
        }

        private void IzracunajNarudzbe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NarudzbeGrid.ItemsSource = NarudzbaDAO.GetNarudzbeOdDo(OdDatePicker3.SelectedDate, DoDatePicker3.SelectedDate).DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska pri ispisu narudzbi\n" + ex.Message);
            }
        }
    }
}
