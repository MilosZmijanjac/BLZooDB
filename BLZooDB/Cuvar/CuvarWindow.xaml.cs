using BLZooDB.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for CuvarWindow.xaml
    /// </summary>
    public partial class CuvarWindow : Window
    {
        Zaposleni zaposleni;
        string typeString = "Čuvar";
        public CuvarWindow(Zaposleni z, bool isManager)
        {
            InitializeComponent();
            zaposleni = z;
            usernameTextBlock.Text = z.Ime + " " + z.Prezime;
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
            if (item == Home && item.IsSelected){DashboardFrame.Content = new CuvarHomePage();}
            else if (item == Inventar && item.IsSelected) { DashboardFrame.Content = new CuvarDodijeliCuvaraPage(); }
            else if (item == Hrana && item.IsSelected) { DashboardFrame.Content = new CuvarUrediHranu(); }
            else if (item == Profile && item.IsSelected) { DashboardFrame.Content = new ProfilePage(zaposleni, typeString); }
            else if (item == Obavjesti && item.IsSelected) { DashboardFrame.Content = new CuvarObavjestiPage(zaposleni.Zaposleni_id); }
            else if (item == Logout && item.IsSelected) { new LoginWindow().Show(); Close(); }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
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
