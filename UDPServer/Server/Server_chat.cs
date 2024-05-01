using Microsoft.EntityFrameworkCore;
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
            Console.WriteLine("Клиент добавлен");
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
        public static async Task<List<Message>> GetMessagesForChat(string chatName)
        {
            var messages = new List<Message>();
    
            try
            {
                // Создаем экземпляр контекста базы данных
                using (var dbContext = new ApplicationContext())
                {
                    // Используем метод Where для выборки сообщений по имени чата
                    var messagesFromDb = await dbContext.Messages
                        .Where(m => m.ChatName == chatName)
                        .ToListAsync();
                        

                    // Добавляем каждое сообщение в список messages
                    messages.AddRange(messagesFromDb);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting messages for chat '{chatName}': {ex.Message}");
            }

            // Возвращаем массив сообщений
            return messages;
        }


    }
}
