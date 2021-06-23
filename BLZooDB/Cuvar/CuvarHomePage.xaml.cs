using System;
using BLZooDB.DAO;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for CuvarHomePage.xaml
    /// </summary>
    public partial class CuvarHomePage : Page
    {
        public CuvarHomePage()
        {
            InitializeComponent();
            try
            {
                CuvariInfoDataGrid.ItemsSource = CuvarDAO.GetHranaDataTable().DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa cuvara\n" + ex.Message);
            }
        }
    }
}
