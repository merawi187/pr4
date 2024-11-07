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

namespace pr4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenLoginPage(object sender, RoutedEventArgs e)
        {
            var loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }
        private void OpenRegisterPage(object sender, RoutedEventArgs e)
        {
            var registerPage = new RegisterPage();
            registerPage.Show();
            this.Close();
        }
    }
}
