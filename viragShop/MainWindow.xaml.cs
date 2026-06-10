using System.Text;
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

namespace viragShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Viragok> viragLista;
        Viragok kivalasztottVirag;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViragMenu_Click(object sender, RoutedEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlViragok());
        }
        private void VasarloMenu_Click(object sender, RoutedEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlVasarlo());
        }
        private void MunkasMenu_Click(object sender, RoutedEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlMunkas());
        }
        private void KilepesMenu_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Vasarlas_Click(object sender, RoutedEventArgs e)
        {
            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(new UserControls.UserControlViragVasarlas());
        }
    }
}