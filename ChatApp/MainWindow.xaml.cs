using System;
using System.Windows;

namespace ChatApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string nameTexBox = "";

        private void CreateChat_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string ipAddress = IPAddress.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Введите имя пользователя!");
                return;
            }

            if (string.IsNullOrEmpty(ipAddress))
            {
                MessageBox.Show("Введите IP адрес");
                return;
            }

            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            Window.GetWindow(this).Close();
        }

        private void LogChat_Click(Object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string ipAddress = IPAddress.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Введите имя пользователя!");
                return;
            }

            if (string.IsNullOrEmpty(ipAddress))
            {
                MessageBox.Show("Введите IP адрес");
                return;
            }

            UserPage userPage = new UserPage(ipAddress, username);
            userPage.Show();
            Window.GetWindow(this).Close();
        }
    }
}
