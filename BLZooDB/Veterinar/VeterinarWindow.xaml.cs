using BLZooDB.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarWindow.xaml
    /// </summary>
    public partial class VeterinarWindow : Window
    {

        Zaposleni zaposleni;
        string typeString = "Veterinar";

        public VeterinarWindow(Zaposleni z, bool isManager)
        {
            InitializeComponent();
            zaposleni = z;
            usernameTextBlock.Text = zaposleni.Ime + " " + zaposleni.Prezime;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
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

            if (item == Home && item.IsSelected){DashboardFrame.Content = new VeterinarHomePage();}
            else if (item == Inventar && item.IsSelected) { DashboardFrame.Content = new VeterinarAzurirajLijekovePage(); }
            else if (item == NoviLijek && item.IsSelected) { DashboardFrame.Content = new VeterinarDodajLijekPage(); }
            else if (item == Profile && item.IsSelected) { DashboardFrame.Content = new ProfilePage(zaposleni, typeString); }
            else if (item == Obavjesti && item.IsSelected) { DashboardFrame.Content = new VeterinarObavjestiPage(); }
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

