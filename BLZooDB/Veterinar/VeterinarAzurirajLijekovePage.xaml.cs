using BLZooDB.DAO;
using BLZooDB.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarAzurirajLijekovePage.xaml
    /// </summary>
    public partial class VeterinarAzurirajLijekovePage : Page
    {
        public VeterinarAzurirajLijekovePage()
        {
            InitializeComponent();
            try
            {
                ListViewMedicine.ItemsSource = LijekDAO.GetLijekoviSvi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa lijekova\n" + ex.Message);
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            int l_id = ((sender as Button).DataContext as Lijek).Lijek_id;
            int l_s = int.Parse(((sender as Button).Parent as StackPanel).Children.OfType<TextBox>().First().Text);

            try
            {
                LijekDAO.UpdateLijek(l_id, l_s);
                MessageBox.Show("Lijek je azuriran");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom azuriranja lijeka\n" + ex.Message);
            }
            
        }
    }
}
