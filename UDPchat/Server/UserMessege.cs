using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPchat.Server
{
    public class UserMessage : Message
    {
        public string SenderUsername { get; set; }

        public UserMessage(string text, string senderUsername)
        {
            Text = text;
            SenderUsername = senderUsername;
            Timestamp = DateTime.Now;
        }
    }
}
