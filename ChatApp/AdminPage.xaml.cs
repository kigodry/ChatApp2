using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChatApp
{
    public partial class AdminPage : Window
    {
        private Socket socket;
        private List<Socket> clients = new List<Socket>();
        private List<string> connectedUsers = new List<string>();

        public AdminPage()
        {
            InitializeComponent();
            IPEndPoint ipPont = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPont);
            socket.Listen(1000);
            ListenToClients();
        }

        private async Task ListenToClients()
        {
            while (true)
            {
                Socket client = await socket.AcceptAsync();
                clients.Add(client);
                ReceiveMessage(client);
            }
        }

        private string GetUserName(Socket client)
        {
            string userName = client.RemoteEndPoint.ToString();
            return userName;
        }

        private async void ReceiveMessage(Socket client)
        {
            string userName = GetUserName(client);

            while (true)
            {
                byte[] bytes = new byte[1024];
                int bytesRead = await client.ReceiveAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
                if (bytesRead == 0) 
                {
                    clients.Remove(client);
                    string disconnectedUser = GetUserName(client);
                    Dispatcher.Invoke(() =>
                    {
                        userList.Items.Remove(disconnectedUser);
                        string disconnectMessage = $"[Сообщение от сервера]: Пользователь {disconnectedUser} отключился.";
                        messageListBox.Items.Add(disconnectMessage);
                    });

                    if (disconnectedUser == "admin")
                    {
                        Dispatcher.Invoke(() =>
                        {
                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window is UserPage)
                                    window.Close();
                            }

                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                        });

                        connectedUsers.Clear(); 
                    }

                    break; 
                }
                string message = Encoding.UTF8.GetString(bytes, 0, bytesRead);

                if (message.Contains(" подключился"))
                {
                    string[] strings = message.Split(' ');
                    Dispatcher.Invoke(() => userList.Items.Add(strings[0]));
                    connectedUsers.Add(strings[0]);
                }
                else if (message.Contains(" отключился"))
                {
                    string[] strings = message.Split(' ');
                    Dispatcher.Invoke(() => userList.Items.Remove(strings[0]));
                    connectedUsers.Remove(strings[0]);
                }

                Dispatcher.Invoke(() => messageListBox.Items.Add($"{userName}: {message}"));

                foreach (var item in clients)
                {
                    SendMessage(item, $"{userName}: {message}");
                }
            }
        }

        private async Task SendMessage(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = $"[Сообщение от сервера]: {messageBox.Text}";
            messageListBox.Items.Add(message);

            foreach (var item in clients)
            {
                SendMessage(item, message);
            }

            messageBox.Clear();
        }

        public void exitClick(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            LogWindow logWindow = new LogWindow();

            StringBuilder sb = new StringBuilder();
            foreach (var item in messageListBox.Items)
            {
                sb.AppendLine(item.ToString());
            }

            logWindow.SetLogText(sb.ToString());

            logWindow.ShowDialog();
        }
    }
}
