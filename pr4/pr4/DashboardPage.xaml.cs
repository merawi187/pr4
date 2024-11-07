using System;
using System.Collections.Generic;
using System.Data;
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

namespace pr4
{
    /// <summary>
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Window
    {
        private string Role { get; }
        public DashboardPage(string role)
        {
            InitializeComponent();
            Role = role;
            SetupUI();
        }
        private void SetupUI()
        {
            WelcomeTextBlock.Text = $"Добро пожаловать, {Role}";
            if (Role == "admin")
            {
                AdminButton.Visibility = Visibility.Visible;
                UserButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                UserButton.Visibility = Visibility.Visible;
                AdminButton.Visibility = Visibility.Collapsed;
            }
        }

        private void BackToMainButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
