using BLZooDB.DAO;
using BLZooDB.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<LogIn> array = new List<LogIn> {
                new LogIn("upravnik","10013"),
                new LogIn("vet mng","10008"),
                new LogIn("vet","10015"),
                new LogIn("cuvar","10014"),
                new LogIn("cuvar mng","10010"),
                new LogIn("shop mng","10003"),
                new LogIn("shop","10018"),
                };
        public LoginWindow()
        {
            InitializeComponent();
            UsernameComboBox.ItemsSource = array;
            UsernameComboBox.DisplayMemberPath = "Pozicija";
            UsernameComboBox.SelectedValuePath = "Id";
            UsernameComboBox.ItemsSource = array;
            
        }
        private void Window_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (int.TryParse(UsernameTextBox.Text, out int id))
                if (ZaposleniDAO.IsValidZaposleni(id, PasswordBox.Password))
                {
                    Console.WriteLine(id);
                    Zaposleni uZaposleni = ZaposleniDAO.GetZaposleni(id);

                    bool isM = ZaposleniDAO.IsMenadzer(id);
                        Console.WriteLine(isM);   
                    switch (uZaposleni.Odjel_id)
                    {
                        case 2:
                            new UpravnikWindow(uZaposleni).Show();
                            Close();
                            break;
                        case 9:
                            new VeterinarWindow(uZaposleni, isM).Show();
                            Close();
                            break;
                        case 15:
                             new CuvarWindow(uZaposleni, isM).Show();
                            Close();
                            break;
                        case 7:
                             new ShopWindow(uZaposleni, isM).Show();
                            Close();
                            break;
                        case 11:
                             new ShopWindow(uZaposleni, isM).Show();
                            Close();
                            break;
                        default:
                            Console.WriteLine("Nema");
                            break;

                    }
                    }
                    else
                    {
                        MessageBox.Show("Ne postoji korisnik");
                    }
                else
                {
                    MessageBox.Show("Ne postoji korisnik");
                }
              } catch(Exception ex)
              {
                  MessageBox.Show("Greska prilikom prijave" +"\n"+ ex.Message);
              }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UsernameComboBox_DropDownClosed(object sender, EventArgs e)
        {
            UsernameTextBox.Text = UsernameComboBox.SelectedValue.ToString();
        }
    }
}
