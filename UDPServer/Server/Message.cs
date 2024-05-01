using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public string SenderUsername { get; set; } 
        public string ChatName { get; set; }
       

        // Конструктор для создания сообщения
        public Message(string text, string senderUsername)
        {
            Text = text;
            Timestamp = DateTime.Now;
            SenderUsername = senderUsername; // Инициализация свойства SenderUsername
        }
    }
}