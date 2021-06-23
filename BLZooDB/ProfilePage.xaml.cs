using BLZooDB.DAO;
using BLZooDB.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        Zaposleni zaposleni;
        public ProfilePage(Zaposleni z, string inType)
        {
            InitializeComponent();
            type.Text = inType;
            id.Text = z.Zaposleni_id.ToString();
            name.Text = z.Ime + " " + z.Prezime;
            passwordCurrent.Password = "password";
            zaposleni = z;

        }
        private void ChangePassButton_Click(object sender, RoutedEventArgs e)
        {
            passwordCurrent.IsEnabled = !passwordCurrent.IsEnabled;
            if (passwordCurrent.IsEnabled)
            {
                passwordCurrent.Password = "";
                passwordNew.Visibility = Visibility.Visible;
                passwordConfirm.Visibility = Visibility.Visible;
                newPassLabel.Visibility = Visibility.Visible;
                confirmPassLabel.Visibility = Visibility.Visible;
                confirmChangePassButton.Visibility = Visibility.Visible;
            }
            else
            {
                passwordCurrent.Password = "......";
                passwordNew.Visibility = Visibility.Hidden;
                passwordConfirm.Visibility = Visibility.Hidden;
                newPassLabel.Visibility = Visibility.Hidden;
                confirmPassLabel.Visibility = Visibility.Hidden;
                confirmChangePassButton.Visibility = Visibility.Hidden;
            }
        }
        private void ConfirmChangePassButton_Click(object sender, RoutedEventArgs e)
        {
            if (zaposleni != null)
            {
                if (passwordCurrent.Password.Equals(zaposleni.Lozinka))
                {
                    if (passwordNew.Password.Equals(passwordConfirm.Password))
                    {
                        try
                        {
                            ZaposleniDAO.UpdateLozinka(zaposleni.Zaposleni_id, passwordCurrent.Password, passwordNew.Password);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Greska kod promijene lozinke" + "\n" +
                                            ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lozinke nisu jednake");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Lozinke nisu jednake");
                    return;
                }
                MessageBox.Show("Lozinka uspjesno izmijenjena");
            }
        }
    }
}
