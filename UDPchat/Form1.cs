using System;
using System.Windows.Forms;
using Server;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UDPChat
{
    public partial class MainForm : Form
    {
        private UDPServer udpServer;
        private string nickname;

        public MainForm(string nickname)
        {
            InitializeComponent();
            this.nickname = nickname;
            udpServer = new UDPServer(nickname);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessageToServer(textBoxMessage.Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectFromServer();
        }

        private void UpdateChatBox(string message)
        {
            listBoxChat.Items.Add(message);
        }

        private void ConnectToServer()
        {
            try
            {
                udpServer.StartListening();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к серверу: {ex.Message}");
            }
        }

        private void DisconnectFromServer()
        {
            try
            {
                udpServer.StopListening();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отключения от сервера: {ex.Message}");
            }
        }

        private void SendMessageToServer(string message)
        {
            try
            {
                udpServer.SendMessage($"{nickname}: {message}"); // Отправляем сообщение с именем пользователя
                string formattedMessage = $"{nickname}: {message}"; // Форматирование сообщения для отображения в чате
                listBoxChat.Items.Add(formattedMessage); // Добавление сообщения в список чата
                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки сообщения: {ex.Message}");
            }
        }

    }
}
