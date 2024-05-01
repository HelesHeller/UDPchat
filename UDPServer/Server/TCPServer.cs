using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace TCPServer
{

    public class TCPServer
    {
        private const int serverPort = 12121;
        private UdpClient client;
        private IPEndPoint serverEndPoint;
        private string nickname;
        private List<string> chatList;
        private List<string> participantList;


        public TCPServer(string nickname)
        {
            client = new UdpClient();
            serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort);
            this.nickname = nickname;
        }

        public void StartListening()
        {
            client.Client.Bind(new IPEndPoint(IPAddress.Any, 12121));
            Thread receiveThread = new Thread(ReceiveMessages);
            receiveThread.Start();
        }

        public void StopListening()
        {
            client.Close();
        }

        private void ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    byte[] data = client.Receive(ref serverEndPoint);
                    string message = Encoding.Unicode.GetString(data);
                    
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Ошибка при приеме сообщения: {ex.Message}");
            }
        }

        public void SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(nickname))
            {
                message = $"{nickname}: {message}";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, serverEndPoint);
            }
            


        }
        public List<string> GetChatList()
            {
                return chatList;
            }

            public List<string> GetParticipantList()
            {
                return participantList;
            }
    }
}
