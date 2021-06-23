using BLZooDB.DAO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BLZooDB
{
    /// <summary>
    /// Interaction logic for VeterinarDodajZivotinjuPage.xaml
    /// </summary>
    public partial class VeterinarDodajZivotinjuPage : Page
    {
        public VeterinarDodajZivotinjuPage()
        {
            InitializeComponent();
            try
            {
                var smjestaji = SmjestajDAO.GetSmjestaji();
                SmjestajComboBox.SelectedValuePath = "Smjestaj_id";
                SmjestajComboBox.DisplayMemberPath = "Smjestaj_naziv";
                SmjestajComboBox.ItemsSource = smjestaji;
            }catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom ispisa smjestaja\n" + ex.Message);
            }
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(BrojHranjenaTextBox.Text, out int broj_h))
                try
                {
                    ZivotinjaDAO.InsertZivotinju(ImeTextBox.Text, VrstaTextBox.Text, DateTime.Parse(DatumRodjenjaDateBox.Text), SpolComboBox.Text,
                        int.Parse(SmjestajComboBox.SelectedValue.ToString()), StanjeComboBox.Text, IshranaComboBox.Text, broj_h, SlikaTextBox.Text);

                }catch(Exception ex)
                {
                    MessageBox.Show("Greska prilikom dodavanja zivotinje\n" + ex.Message);
                }
            else
            {
                MessageBox.Show("Podaci nisu validni");

                return;
            }
            MessageBox.Show("Uspjesno dodana zivotinja");
            NavigationService.Navigate(new VeterinarHomePage());
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
