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
    /// Interaction logic for UserControlViragok.xaml
    /// </summary>
    public partial class UserControlViragok : UserControl
    {
        List<Viragok> viragok;
        Viragok kivalasztottVirag;

        public UserControlViragok()
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

            ViragneveText.Text = "";
            ViragLeirasaText.Text = "";
            ViragaraText.Text = "";
            MennyisegText.Text = "";
        }

        private void datagridFelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridViragok.SelectedItem == null)
                return;

            mentesBtn.Visibility = Visibility.Collapsed;
            modositasBtn.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;

            kivalasztottVirag = (Viragok)datagridViragok.SelectedItem;

            ViragneveText.Text = kivalasztottVirag.Nev;
            ViragLeirasaText.Text = kivalasztottVirag.Leiras;
            ViragaraText.Text = kivalasztottVirag.Ar.ToString();
            MennyisegText.Text = kivalasztottVirag.Mennyiseg.ToString();
        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            Viragok ujVirag = new Viragok()
            {
                Nev = ViragneveText.Text,
                Leiras = ViragLeirasaText.Text,
                Ar = int.Parse(ViragaraText.Text),
                Mennyiseg = int.Parse(MennyisegText.Text)
            };

            var viragRepo = new GenericRepository<Viragok>(App.databasePath);
            viragRepo.Insert(ujVirag);

            AdatbazisLekerdezes();
        }

        private void modositasBtn_Click(object sender, RoutedEventArgs e)
        {
            kivalasztottVirag.Nev = ViragneveText.Text;
            kivalasztottVirag.Leiras = ViragLeirasaText.Text;
            kivalasztottVirag.Ar = int.Parse(ViragaraText.Text);
            kivalasztottVirag.Mennyiseg = int.Parse(MennyisegText.Text);

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
