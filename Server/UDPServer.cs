using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class UDPServer
    {
        private const int serverPort = 12345;
        private UdpClient client;
        private IPEndPoint serverEndPoint;
        private string nickname;

        public UDPServer(string nickname)
        {
            client = new UdpClient();
            serverEndPoint = new IPEndPoint(IPAddress.Parse("26.129.29.176"), serverPort);
            this.nickname = nickname;
        }

        public void StartListening()
        {
            client.Client.Bind(new IPEndPoint(IPAddress.Any, 12345));
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
                    // Handle received message
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
    }
}
