using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChatApp
{
    public partial class UserPage : Window
    {
        private Socket server;
        private string username;
        private bool isAdminDisconnected = false;
        private List<string> connectedUsers = new List<string>();

        public UserPage(string ipText, string username)
        {
            InitializeComponent();
            this.username = username;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(new IPEndPoint(IPAddress.Parse(ipText), 8888));
            SendMessage(username + " подключился");
            ReceiveMessage();
        }

        private async Task SendMessage(string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await server.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);

            if (message.Contains("/disconnect"))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private async Task ReceiveMessage()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                int bytesRead = await server.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes, 0, bytesRead);

                if (message.Contains(" подключился"))
                {
                    string[] strings = message.Split(' ');
                    string username = strings[0];
                    connectedUsers.Add(username);
                    Dispatcher.Invoke(() => userList.Items.Add(username));
                }
                else if (message.Contains(" отключился"))
                {
                    string[] strings = message.Split(' ');
                    string username = strings[0];
                    connectedUsers.Remove(username);
                    Dispatcher.Invoke(() => userList.Items.Remove(username));
                }

                Dispatcher.Invoke(() => messageListBox.Items.Add(message));

                if (message.Contains("[Сообщение от сервера]: Пользователь admin отключился."))
                {
                    string disconnectedUser = "admin";
                    Dispatcher.Invoke(() =>
                    {
                        userList.Items.Remove(disconnectedUser);
                        messageListBox.Items.Add($"[Сообщение от сервера]: Пользователь {disconnectedUser} отключился.");
                    });
                    break;
                }
            }
        }

        private void exitClick1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void sendButton_Click1(object sender, RoutedEventArgs e)
        {
            SendMessage(username + ": " + messageBox.Text);
            messageBox.Clear();
        }
    }
}
