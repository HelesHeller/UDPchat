using System;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UDPChat
{
    public partial class MainForm : Form
    {
        
        private string nickname;


        public MainForm(string nickname)
        {
            InitializeComponent();
            this.nickname = nickname;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //ConnectToServer();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendMessageToServer(textBoxMessage.Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DisconnectFromServer();
        }

        private void UpdateChatBox(string message)
        {
            listBoxChat.Items.Add(message);
            
        }


        


        

        private void SendMessageToServer(string message)
        {
            try
            {
                //TCPServer.SendMessage($"{nickname}: {message}"); // Отправляем сообщение с именем пользователя
                string formattedMessage = $"{nickname}: {message}"; // Форматирование сообщения для отображения в чате
                listBoxChat.Items.Add(formattedMessage); // Добавление сообщения в список чата
                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отправки сообщения: {ex.Message}");
            }
        }

        private void UpdateChatList(string[] chatList)
        {
            panelChats.Controls.Clear(); // Очищаем предыдущий список чатов

            // Создаем кнопку для каждого чата и добавляем их на панель
            for (int i = 0; i < chatList.Length; i++)
            {
                Button chatButton = new Button();
                chatButton.Text = chatList[i];
                chatButton.Click += (sender, e) => JoinChat(chatButton.Text);
                chatButton.Dock = DockStyle.Top;
                panelChats.Controls.Add(chatButton);
            }
        }

        private void UpdateParticipantList(string[] participantList)
        {
            panelParticipants.Controls.Clear(); // Очищаем предыдущий список участников

            // Создаем метку для каждого участника и добавляем их на панель
            for (int i = 0; i < participantList.Length; i++)
            {
                Label participantLabel = new Label();
                participantLabel.Text = participantList[i];
                participantLabel.Dock = DockStyle.Top;
                panelParticipants.Controls.Add(participantLabel);
            }
        }

        private void JoinChat(string chatName)
        {
            // Здесь можно реализовать логику присоединения к выбранному чату
            MessageBox.Show($"Вы присоединились к чату '{chatName}'");
        }

    }
}
