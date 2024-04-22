using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPChat
{
    internal class ChatHistory
    {
        private Dictionary<string, List<string>> history;

        public ChatHistory()
        {
            history = new Dictionary<string, List<string>>();
        }
        public void AddMessage(string chatName, string message)
        {
            if (!history.ContainsKey(chatName))
            {
                history[chatName] = new List<string>();
            }

            history[chatName].Add(message);
        }
        public List<string> GetChatHistory(string chatName)
        {
            if (history.ContainsKey(chatName))
            {
                return history[chatName];
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
