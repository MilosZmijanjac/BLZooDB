using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for UpravnikHomePage.xaml
    /// </summary>
    public partial class UpravnikHomePage : Page
    {
        public UpravnikHomePage()
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
                MessageBox.Show("Greska prilikom racunanja ukupnog prihoda" + "\n" + ex.Message);
            }

        }

        private void IzracunajUlaznice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UlazniceGrid.ItemsSource = NarudzbaDAO.GetProdaneUlazniceOdDoDataTable(OdDatePicker1.SelectedDate, DoDatePicker1.SelectedDate).DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom generisanja izvjestaja o prodanim ulaznicama" + "\n" + ex.Message);
            }
        }

        private void IzracunajProizvode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProizvodiGrid.ItemsSource = NarudzbaDAO.GetProdaniProizvodiOdDo(OdDatePicker2.SelectedDate, DoDatePicker2.SelectedDate).DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom generisanja izvjestaja o prodanim proizvodima" + "\n" + ex.Message);
            }
        }

        private void IzracunajNarudzbe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NarudzbeGrid.ItemsSource = NarudzbaDAO.GetNarudzbeOdDo(OdDatePicker3.SelectedDate, DoDatePicker3.SelectedDate).DefaultView;
            } catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom generisanja izvjestaja o narudzbama" + "\n" + ex.Message);
            }
        }
    }
}

