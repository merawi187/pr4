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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private const string AdminAccessCode = "12345";
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string newLogin =NewLoginTextBox.Text;
            string newPassword = NewPasswordBox.Password;
            string ConfirmPassword = ConfirmPasswordBox.Password;
            string accessCode = AccessCodeTextBox.Text;

            if(string.IsNullOrEmpty(newLogin) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(ConfirmPassword))
            {
                RegisterErrorTextBlock.Text = "Заполнены не все поля!";

                RegisterErrorTextBlock.Visibility = Visibility.Visible;
                return;
            }
            if (newPassword != ConfirmPassword)
            {
                RegisterErrorTextBlock.Text = "Пароли не совпадают!";
                RegisterErrorTextBlock.Visibility = Visibility.Visible; 
                return;
            }
            string role = accessCode == AdminAccessCode ? "admin" : "user";
            if (! UserStore.RegisterUser(newLogin, newPassword, role))
            {
                RegisterErrorTextBlock.Text = "Пользователь с таким логином уже существует!";
                RegisterErrorTextBlock.Visibility = Visibility.Visible; 
                return;
            }
            MessageBox.Show("Регистрация завершена успешно!", "Успех");
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
