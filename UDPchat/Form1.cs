using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPServer;
using TCPServer.Server;


namespace TCPChat
{
    public partial class MainForm : Form
    {
        private string nickname;
        private ChatHistory chatHistory;
        private TCPServer.ApplicationContext dbContext;

        public MainForm(string nickname)
        {
            InitializeComponent();
            this.nickname = nickname;
            chatHistory = new ChatHistory();
            dbContext = new TCPServer.ApplicationContext();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var dbContext = new ApplicationContext())
                {
                    var chatService = new ChatService(dbContext);
                    var chatList = chatService.GetChatList();
                    UpdateChatList(chatList);
                }

                // Additional code as necessary
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async Task<string[]> GetParticipantListFromServer()
        {
            return await Server_chat.GetParticipantList();
        }

        private void ReceiveMessage(string chatName, TCPServer.Message message)
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
            var messages = await GetMessagesForChat(chatName);
            foreach (var message in messages)
            {
                ReceiveMessage(chatName, message);
            }
        }
        private void buttonAddChat_Click(object sender, EventArgs e)
        {
            using (var addChatForm = new AddChatForm())
            {
                if (addChatForm.ShowDialog() == DialogResult.OK)
                {
                    var chatName = addChatForm.ChatName;
                    var chatService = new ChatService(new ApplicationContext());
                    chatService.AddChat(chatName);
                    LoadChats();  // Update the chat list
                }
            }
        }
        private void LoadChats()
        {
            listBoxChat.Items.Clear();
            var chatService = new ChatService(new ApplicationContext());
            var chats = chatService.GetChatList();
            foreach (var chat in chats)
            {
                listBoxChat.Items.Add(chat);
            }
        }


        private async Task<List<TCPServer.Message>> GetMessagesForChat(string chatName)
        {
            try
            {
                // Создание экземпляра клиента чата для взаимодействия с сервером
                Server_chat server_chat = new Server_chat();

                // Получение сообщений для указанного чата с сервера
                var messages = await Server_chat.GetMessagesForChat(chatName);

                return messages;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, возникающих при получении сообщений
                MessageBox.Show($"Ошибка при получении сообщений для чата '{chatName}': {ex.Message}");
                return new List<TCPServer.Message> { };
            }
        }
    }
}
