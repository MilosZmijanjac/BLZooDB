using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for UpravnikHranaPage.xaml
    /// </summary>
    public partial class UpravnikHranaPage : Page
    {
        public UpravnikHranaPage()
        {
            InitializeComponent();
            try
            {
                HranaDataGrid.ItemsSource = HranaDAO.GetHranaDataTable().DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom generisanja liste hrane" + "\n" + ex.Message);
            }
        }
    }
}
