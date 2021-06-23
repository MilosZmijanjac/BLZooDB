using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for UpravnikLijekoviPage.xaml
    /// </summary>
    public partial class UpravnikLijekoviPage : Page
    {
        public UpravnikLijekoviPage()
        {
            InitializeComponent();
            try
            {
                LijekoviDataGrid.ItemsSource = LijekDAO.GetLijekoviDataTable().DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom generisanja liste lijekova " + "\n" + ex.Message);
            }
        }
    }
}
