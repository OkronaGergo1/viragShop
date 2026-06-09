using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using viragShop.Models;
using viragShop.Services;

namespace viragShop.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlMunkas.xaml
    /// </summary>
    public partial class UserControlMunkas : UserControl
    {
        List<Munkas> munkasok;
        Munkas kivalasztottMunkas;

        public UserControlMunkas()
        {
            InitializeComponent();
            AdatbazisLekerdezes();
        }

        private void AdatbazisLekerdezes()
        {
            var repo = new GenericRepository<Munkas>(App.databasePath);
            munkasok = repo.GetAll();

            datagridViragok.ItemsSource = munkasok;

            mentesBtn.Visibility = Visibility.Visible;
            modositasBtn.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;

            nevText.Text = "";
            SzületesidatumText.Text = "";
            LakcimText.Text = "";
            BeosztasText.Text = "";
            JelszoText.Text = "";
        }

        private void datagridFelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridViragok.SelectedItem == null)
                return;

            kivalasztottMunkas = (Munkas)datagridViragok.SelectedItem;

            mentesBtn.Visibility = Visibility.Collapsed;
            modositasBtn.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;

            nevText.Text = kivalasztottMunkas.Nev;
            SzületesidatumText.Text = kivalasztottMunkas.SzulDatum.ToString();
            LakcimText.Text = kivalasztottMunkas.Lakcim;
            BeosztasText.Text = kivalasztottMunkas.Beosztas;
            JelszoText.Text = kivalasztottMunkas.Jelszo;
        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            Munkas ujMunkas = new Munkas()
            {
                Nev = nevText.Text,
                SzulDatum = int.Parse(SzületesidatumText.Text),
                Lakcim = LakcimText.Text,
                Beosztas = BeosztasText.Text,
                Jelszo = PasswordHelper.HashPassword( JelszoText.Text)  
            };

            var repo = new GenericRepository<Munkas>(App.databasePath);
            repo.Insert(ujMunkas);

            AdatbazisLekerdezes();
        }

        private void modositasBtn_Click(object sender, RoutedEventArgs e)
        {
            kivalasztottMunkas.Nev = nevText.Text;
            kivalasztottMunkas.SzulDatum = int.Parse(SzületesidatumText.Text);
            kivalasztottMunkas.Lakcim = LakcimText.Text;
            kivalasztottMunkas.Beosztas = BeosztasText.Text;

            if (!string.IsNullOrWhiteSpace(JelszoText.Text))
            {
                kivalasztottMunkas.Jelszo = PasswordHelper.HashPassword(JelszoText.Text);
            }

            var repo = new GenericRepository<Munkas>(App.databasePath);
            repo.Update(kivalasztottMunkas);

            AdatbazisLekerdezes();
        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var repo = new GenericRepository<Munkas>(App.databasePath);
            repo.Delete(kivalasztottMunkas);

            AdatbazisLekerdezes();
        }
    }
}
