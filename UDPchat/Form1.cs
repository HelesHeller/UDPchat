using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPServer.Server;

namespace TCPChat
{
    public partial class MainForm : Form
    {
        private string nickname;
        private ChatHistory chatHistory;

        public MainForm(string nickname)
        {
            InitializeComponent();
            this.nickname = nickname;
            chatHistory = new ChatHistory();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            string[] chatList = GetChatList();
            UpdateChatList(chatList);

            string[] participantList = await GetParticipantListFromServer();
            UpdateParticipantList(participantList);

            if (chatList.Length > 0)
            {
                JoinChat(chatList[0]);
            }
        }

        private async Task<string[]> GetParticipantListFromServer()
        {
            return await Server_chat.GetParticipantList();
        }

        private void ReceiveMessage(string chatName, string message)
        {
            chatHistory.AddMessage(chatName, message);
            UpdateChatHistory(chatName);
        }

        private void UpdateChatHistory(string chatName)
        {
            var history = chatHistory.GetChatHistory(chatName);
            listBoxChat.Items.Clear();
            foreach (var message in history)
            {
                listBoxChat.Items.Add(message);
            }
        }

        public static string[] GetChatList()
        {
            // Метод для получения списка чатов из сервера
            return new string[] { "Chat 1", "Chat 2", "Chat 3" }; // Пример возвращаемого списка чатов
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessageToServer(textBoxMessage.Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Код для отключения от сервера при закрытии формы
        }

        private void SendMessageToServer(string message)
        {
            try
            {
                string formattedMessage = $"{nickname}: {message}";
                listBoxChat.Items.Add(formattedMessage);
                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки сообщения: {ex.Message}");
            }
        }

        private void UpdateChatList(string[] chatList)
        {
            panelChats.Controls.Clear();
            foreach (var chatName in chatList)
            {
                Button chatButton = new Button();
                chatButton.Text = chatName;
                chatButton.Click += (sender, e) => JoinChat(chatName);
                chatButton.Dock = DockStyle.Top;
                panelChats.Controls.Add(chatButton);
            }
        }

        private void UpdateParticipantList(string[] participantList)
        {
            panelParticipants.Controls.Clear();
            foreach (var participant in participantList)
            {
                Label participantLabel = new Label();
                participantLabel.Text = participant;
                participantLabel.Dock = DockStyle.Top;
                panelParticipants.Controls.Add(participantLabel);
            }
        }

        private async void JoinChat(string chatName)
        {
            MessageBox.Show($"Вы присоединились к чату '{chatName}'");

            // Код для присоединения к выбранному чату на сервере и загрузки сообщений чата
            string[] messages = await GetMessagesForChat(chatName);
            foreach (string message in messages)
            {
                ReceiveMessage(chatName, message);
            }
        }

        private async Task<string[]> GetMessagesForChat(string chatName)
        {
            try
            {
                // Создание экземпляра клиента чата для взаимодействия с сервером
                Server_chat server_chat = new Server_chat();

                // Получение сообщений для указанного чата с сервера
                string[] messages = Server_chat.GetMessageForChat(chatName).Result;

                return await Server_chat.GetMessagesForChat(chatName);
            }
            catch (Exception ex)
            {
                // Обработка ошибок, возникающих при получении сообщений
                MessageBox.Show($"Ошибка при получении сообщений для чата '{chatName}': {ex.Message}");
                return new string[] { };
            }
        }
    }
}
