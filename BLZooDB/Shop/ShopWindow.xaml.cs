using BLZooDB.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        Zaposleni zaposleni;
        string typeString = "Prodavač";
        
        public ShopWindow(Zaposleni z, bool isManager)
        {
            InitializeComponent();
            zaposleni = z;
            if (isManager)
            {
                typeString = "Menadžer prodavnice";
            }
            if (!isManager)
            {
                Home.Visibility = Visibility.Collapsed;
                NoviProizvod.Visibility = Visibility.Collapsed;
                Obavjesti.Visibility = Visibility.Collapsed;
            }
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
            if (item == Home && item.IsSelected){DashboardFrame.Content = new ShopHomePage();}
            else if (item == Shop && item.IsSelected) { DashboardFrame.Content = new ShopOdabirPage(0); }
            else if (item == Inventar && item.IsSelected) { DashboardFrame.Content = new ShopOdabirPage(1); }
            else if (item == NoviProizvod && item.IsSelected) { DashboardFrame.Content = new ShopOdabirPage(2); }
            else if (item == Profile && item.IsSelected) { DashboardFrame.Content = new ProfilePage(zaposleni, typeString); }
            else if (item == Obavjesti && item.IsSelected) { DashboardFrame.Content = new ShopObavjestiPage(zaposleni.Zaposleni_id); }
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
