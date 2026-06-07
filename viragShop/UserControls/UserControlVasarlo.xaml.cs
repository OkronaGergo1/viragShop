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

namespace viragShop.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlVasarlo.xaml
    /// </summary>
    public partial class UserControlVasarlo : UserControl
    {
        List<Viragok> viragok;
        Viragok kivalasztottVirag;

        public UserControlVasarlo()
        {
            InitializeComponent();
            AdatbazisLekerdezes();
        }

        private void AdatbazisLekerdezes()
        {
            var viragRepo = new GenericRepository<Viragok>(App.databasePath);
            var lekerdezes = viragRepo.GetAll();
            datagridViragok.ItemsSource = lekerdezes;

            mentesBtn.Visibility = Visibility.Visible;
            modositasBtn.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;

            nevText.Text = "";
            SzületesidatumText.Text = "";
            LakcimText.Text = "";
            IranyitoszamText.Text = "";
        }

        private void datagridFelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridViragok.SelectedItem == null)
                return;

            mentesBtn.Visibility = Visibility.Collapsed;
            modositasBtn.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;

            kivalasztottVirag = (Viragok)datagridViragok.SelectedItem;

            nevText.Text = kivalasztottVirag.Nev;
            SzületesidatumText.Text = kivalasztottVirag.Leiras;
            LakcimText.Text = kivalasztottVirag.Ar.ToString();
            IranyitoszamText.Text = kivalasztottVirag.Mennyiseg.ToString();
        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            Viragok ujVirag = new Viragok()
            {
                Nev = nevText.Text,
                Leiras = SzületesidatumText.Text,
                Ar = int.Parse(LakcimText.Text),
                Mennyiseg = int.Parse(IranyitoszamText.Text)
            };

            var viragRepo = new GenericRepository<Viragok>(App.databasePath);
            viragRepo.Insert(ujVirag);

            AdatbazisLekerdezes();
        }

        private void modositasBtn_Click(object sender, RoutedEventArgs e)
        {
            kivalasztottVirag.Nev = nevText.Text;
            kivalasztottVirag.Leiras = SzületesidatumText.Text;
            kivalasztottVirag.Ar = int.Parse(LakcimText.Text);
            kivalasztottVirag.Mennyiseg = int.Parse(IranyitoszamText.Text);

            var viragRepo = new GenericRepository<Viragok>(App.databasePath);
            viragRepo.Update(kivalasztottVirag);

            AdatbazisLekerdezes();
        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var viragRepo = new GenericRepository<Viragok>(App.databasePath);
            viragRepo.Delete(kivalasztottVirag);

            AdatbazisLekerdezes();
        }
    }
}
