using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for ShopObavjestiPage.xaml
    /// </summary>
    public partial class ShopObavjestiPage : Page
    {
        public ShopObavjestiPage(int id)
        {
            InitializeComponent();
            try
            {
                ObavjestiGrid.ItemsSource = ProizvodDAO.GetShopObavjestiDataTable(id).DefaultView;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska pri ispisu proizvoda\n" + ex.Message);
            }
        }
    }
}
