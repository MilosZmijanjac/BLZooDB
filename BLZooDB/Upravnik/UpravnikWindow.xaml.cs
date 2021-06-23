using BLZooDB.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for UpravnikWindow.xaml
    /// </summary>
    public partial class UpravnikWindow : Window
    {
        Zaposleni zaposleni;
        public UpravnikWindow(Zaposleni z)
        {
            InitializeComponent();
            zaposleni = z;
            usernameTextBlock.Text = z.Ime + " " + z.Prezime;

        }
        public void Window_OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewMenu.SelectedItems.Clear();

            var item = sender as ListViewItem;
            if (item != null)
            {
                item.IsSelected = true;
                ListViewMenu.SelectedItem = item;
            }
        }
        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;

            if (item == Home && item.IsSelected){DashboardFrame.Content = new UpravnikHomePage();}
            else if (item == EmployeeList && item.IsSelected) { DashboardFrame.Content = new UpravnikZaposleniListPage(); }
            else if (item == FoodList && item.IsSelected) { DashboardFrame.Content = new UpravnikHranaPage(); }
            else if (item == MedicineList && item.IsSelected) { DashboardFrame.Content = new UpravnikLijekoviPage(); }
            else if (item == Profile && item.IsSelected) { DashboardFrame.Content = new ProfilePage(zaposleni, "Upravnik Zoo vrta"); }
            else if (item == Logout && item.IsSelected) { new LoginWindow().Show(); Close(); }
        }

        public void Minimise_Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        public void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
