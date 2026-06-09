using SQLite;
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
using System.Windows.Shapes;
using viragShop.Models;
using viragShop.Services;


namespace viragShop
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string felhasznalonevInput = loginUserTxt.Text;
            string jelszoInput = PasswordHelper.HashPassword(loginPasswordText.Password);
            if (string.IsNullOrEmpty(felhasznalonevInput) || string.IsNullOrEmpty(loginPasswordText.Password))
            {
                MessageBox.Show("Felhasználónév és jelszó megadása kötelező!");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                var vasarlo = connection.Table<Vasarlo>()
                    .FirstOrDefault(v => v.Nev == felhasznalonevInput);
                if (vasarlo != null)
                {
                    if (vasarlo.Jelszo == jelszoInput)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Hibás jelszó!");
                        return;
                    }
                }

                var munkas = connection.Table<Munkas>()
                    .FirstOrDefault(m => m.Nev == felhasznalonevInput);

                if (munkas != null)
                {
                    if (munkas.Jelszo == jelszoInput)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Hibás jelszó!");
                        return;
                    }
                }
                MessageBox.Show("Belépés megtagadva! Nincs ilyen felhasználónév.");
            }
        }
    }
}
