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
    /// Interaction logic for UserControlVasarlo.xaml
    /// </summary>
    public partial class UserControlVasarlo : UserControl
    {
        List<Vasarlo> vasarlok;
        Vasarlo kivalasztottVasarlo;

        public UserControlVasarlo()
        {
            InitializeComponent();
            AdatbazisLekerdezes();
        }

        private void AdatbazisLekerdezes()
        {
            var repo = new GenericRepository<Vasarlo>(App.databasePath);
            vasarlok = repo.GetAll();

            datagridViragok.ItemsSource = vasarlok;

            mentesBtn.Visibility = Visibility.Visible;
            modositasBtn.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;

            nevText.Text = "";
            SzületesidatumText.Text = "";
            LakcimText.Text = "";
            IranyitoszamText.Text = "";
            JelszoText.Text = "";
        }

        private void datagridFelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridViragok.SelectedItem == null)
                return;

            kivalasztottVasarlo = (Vasarlo)datagridViragok.SelectedItem;

            mentesBtn.Visibility = Visibility.Collapsed;
            modositasBtn.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;

            nevText.Text = kivalasztottVasarlo.Nev;
            SzületesidatumText.Text = kivalasztottVasarlo.SzulDatum.ToString();
            LakcimText.Text = kivalasztottVasarlo.Lakcim;
            IranyitoszamText.Text = kivalasztottVasarlo.Iranyitoszam.ToString();
            JelszoText.Text = "";
        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            Vasarlo ujVasarlo = new Vasarlo()
            {
                Nev = nevText.Text,
                SzulDatum = int.Parse(SzületesidatumText.Text),
                Lakcim = LakcimText.Text,
                Iranyitoszam = int.Parse(IranyitoszamText.Text),
                Jelszo = PasswordHelper.HashPassword(JelszoText.Text)
            };

            var repo = new GenericRepository<Vasarlo>(App.databasePath);
            repo.Insert(ujVasarlo);

            AdatbazisLekerdezes();
        }

        private void modositasBtn_Click(object sender, RoutedEventArgs e)
        {
            kivalasztottVasarlo.Nev = nevText.Text;
            kivalasztottVasarlo.SzulDatum = int.Parse(SzületesidatumText.Text);
            kivalasztottVasarlo.Lakcim = LakcimText.Text;
            kivalasztottVasarlo.Iranyitoszam = int.Parse(IranyitoszamText.Text);

            if (!string.IsNullOrWhiteSpace(JelszoText.Text))
            {
                kivalasztottVasarlo.Jelszo = PasswordHelper.HashPassword(JelszoText.Text);
            }

            var repo = new GenericRepository<Vasarlo>(App.databasePath);
            repo.Update(kivalasztottVasarlo);

            AdatbazisLekerdezes();
        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var repo = new GenericRepository<Vasarlo>(App.databasePath);
            repo.Delete(kivalasztottVasarlo);

            AdatbazisLekerdezes();
        }
    }
}
