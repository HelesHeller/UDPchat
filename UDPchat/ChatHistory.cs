
using TCPServer;

namespace TCPChat
{
    internal class ChatHistory
    {
        private Dictionary<string, List<string>> history;

        public ChatHistory()
        {
            history = new Dictionary<string, List<string>>();
        }
        public void AddMessage(string chatName, TCPServer.Message message)
        {
            if (!history.ContainsKey(chatName))
            {
                history[chatName] = new List<string>();
            }

            history[chatName].Add(message.Text);
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
