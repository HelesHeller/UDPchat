using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer.Server
{
    public class Server_chat
    {
        private static Random random = new Random();
        private static List<TcpClient> clients = new List<TcpClient>(); // Список клиентов

        private static string[] chatSpeek = {
            "Чого мовчим?",
            "Я чекаю на розпусту...",
            // остальные фразы чата
        };

        public static string GetRandomChat()
        {
            int index = random.Next(chatSpeek.Length);
            return chatSpeek[index];
        }

        public static async Task ChatBot(IPAddress localAddr)
        {
            TcpClient botClient = new TcpClient();

            try
            {
                await botClient.ConnectAsync(localAddr, 7777);
                NetworkStream stream = botClient.GetStream();
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                await writer.WriteLineAsync("Chat-Bot");
                await writer.WriteLineAsync("botochat");

                string response = await reader.ReadLineAsync();
                bool authorized = bool.Parse(response);

                if (authorized)
                {
                    string botUsername = "Chat-Bot";
                    await writer.WriteLineAsync(botUsername);
                    while (true)
                    {
                        string chatSpeek = GetRandomChat();
                        await BroadcastMessageAsync($"{botUsername}: {chatSpeek}");
                        await Task.Delay(20000);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ChatBot Exception: {e.Message}");
            }
            finally
            {
                botClient.Close();
            }
        }

        public static async Task AddClient(TcpClient client)
        {
            clients.Add(client);
        }

        public static async Task RemoveClient(TcpClient client)
        {
            clients.Remove(client);
        }

        public static async Task<string[]> GetParticipantList()
        {
            List<string> participants = new List<string>();
            foreach (TcpClient client in clients)
            {
                if (client.Connected)
                {
                    // Проверяем, подключен ли клиент
                    NetworkStream stream = client.GetStream();
                    if (stream.CanRead)
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        string username = await reader.ReadLineAsync();
                        participants.Add(username);
                    }
                }
            }
            return participants.ToArray();
        }

        public static async Task BroadcastMessageAsync(string message)
        {
            foreach (TcpClient client in clients)
            {
                try
                {
                    if (client.Connected)
                    {
                        NetworkStream stream = client.GetStream();
                        if (stream.CanWrite)
                        {
                            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
                            await writer.WriteLineAsync(message);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error broadcasting message to client: {e.Message}");
                }
            }
        }
        public static async Task<string[]> GetMessagesForChat(string chatName)
        {
            List<string> messages = new List<string>();
            // Здесь может быть логика получения сообщений для указанного чата из базы данных или другого источника данных
            // Например, если сообщения хранятся в базе данных, можно сделать запрос к базе для получения всех сообщений для данного чата
            // После получения сообщений их можно добавить в список messages

            // Пример:
             using (var dbContext = new MyDbContext())
             {
                var messagesFromDb = await dbContext.Messages.Where(m => m.ChatName == chatName).ToListAsync();
                foreach (var message in messagesFromDb)
                {
                    messages.Add(message.Content);
                }
             }

            // Затем возвращаем массив сообщений
            return messages.ToArray();
        }

    }
}
