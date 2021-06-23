using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for CuvarObavjestiPage.xaml
    /// </summary>
    public partial class CuvarObavjestiPage : Page
    {
        public CuvarObavjestiPage(int id)
        {
            InitializeComponent();
            try
            {
                ZivotinjeGrid.ItemsSource = CuvarDAO.GetCuvarObavjestiDataTable(id).DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa obavjesti\n" + ex.Message);
            }
        }
    }
}
