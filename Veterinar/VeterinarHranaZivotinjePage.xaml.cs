using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarHranaZivotinjePage.xaml
    /// </summary>
    public partial class VeterinarHranaZivotinjePage : Page
    {
        public VeterinarHranaZivotinjePage(int id)
        {
            InitializeComponent();
            try
            {
                HranaZivotinjeDataGrid.ItemsSource = HranaDAO.GetHranaZivotinjeDataTable(id).DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa hrane zivotinje\n" + ex.Message);
            }
        }
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
