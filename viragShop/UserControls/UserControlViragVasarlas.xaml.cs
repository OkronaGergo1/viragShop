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
    /// Interaction logic for UserControlViragVasarlas.xaml
    /// </summary>
    public partial class UserControlViragVasarlas : UserControl
    {
        public UserControlViragVasarlas()
        {
            InitializeComponent();
            Betoltes();
        }

        private void Betoltes()
        {
            var repo = new GenericRepository<Viragok>(App.databasePath);
            var viragLista = repo.GetAll();

            viragListaControl.ItemsSource = viragLista;
        }

        private void Vasarlas_Click(object sender, RoutedEventArgs e)
        {
            var gomb = sender as Button;
            var virag = gomb.DataContext as Viragok;

            MessageBox.Show($"Megvásárlásra kiválasztva: {virag.Nev}");
        }

    }
}
