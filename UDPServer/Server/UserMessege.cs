using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    public class UserMessage : Message
    {
        
        public string SenderUsername { get; set; }
        public DateTime Timestamp { get; set; } // Добавленное свойство

        public UserMessage(string text, string senderUsername) : base(text, senderUsername)
        {
            // Остальная инициализация свойств класса UserMessage
            Text = text;
            SenderUsername = senderUsername;
            Timestamp = DateTime.Now;
        }
    }
}
