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
                //TCPServer.SendMessage($"{nickname}: {message}"); // ���������� ��������� � ������ ������������
                string formattedMessage = $"{nickname}: {message}"; // �������������� ��������� ��� ����������� � ����
                listBoxChat.Items.Add(formattedMessage); // ���������� ��������� � ������ ����
                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �������� ���������: {ex.Message}");
            }
        }

        private void UpdateChatList(string[] chatList)
        {
            panelChats.Controls.Clear(); // ������� ���������� ������ �����

            // ������� ������ ��� ������� ���� � ��������� �� �� ������
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
            panelParticipants.Controls.Clear(); // ������� ���������� ������ ����������

            // ������� ����� ��� ������� ��������� � ��������� �� �� ������
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
            // ����� ����� ����������� ������ ������������� � ���������� ����
            MessageBox.Show($"�� �������������� � ���� '{chatName}'");
        }

    }
}
