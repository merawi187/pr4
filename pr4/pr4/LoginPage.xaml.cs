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

namespace pr4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ErrorTextBlock.Text = "Заполнены не все поля!";
                ErrorTextBlock.Visibility = Visibility.Visible;
                return;
            }
            if (UserStore.ValidateUser(login, password))
            {
                string role = UserStore.GetUserRole(login);
                MessageBox.Show("Добро пожаловать!");
                var dashboard = new DashboardPage(role);
                dashboard.Show();
                this.Close();
            }
            else
            {
                ErrorTextBlock.Text = "Неверный логин или пароль!";
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
