using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarObavjestiPage.xaml
    /// </summary>
    public partial class VeterinarObavjestiPage : Page
    {
        public VeterinarObavjestiPage()
        {
            InitializeComponent();
            try
            {
                LijekoviGrid.ItemsSource = LijekDAO.GetVetAlertsLijekovi().DefaultView;
                HranaGrid.ItemsSource = HranaDAO.GetVetAlertsHrana().DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom prikaza obavjesti\n " + ex.Message);
            }
        }
    }
}
