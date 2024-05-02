using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPServer;
using Microsoft.EntityFrameworkCore;

namespace TCPChat
{
    internal class ChatService
    {

        private readonly ApplicationContext dbContext;

        public ChatService(ApplicationContext context)
        {
            dbContext = context;
        }

        public string[] GetChatList()
        {
            // Fetch chat names from the database
            return dbContext.Chats.Select(c => c.ChatName).ToArray();
        }

        public void AddChat(string chatName)
        {
            // Add a new chat to the database
            
            var newChat = new Chat { ChatName = chatName };
            dbContext.Chats.Add(newChat);
            dbContext.SaveChanges();
        }

        public void DeleteChat(string chatName)
        {
            // Find and remove a chat from the database
            var chatToDelete = dbContext.Chats.FirstOrDefault(c => c.ChatName == chatName);
            if (chatToDelete != null)
            {
                dbContext.Chats.Remove(chatToDelete);
                dbContext.SaveChanges();
            }
        }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
    }

    public class Chat
    {
        public int ChatId { get; set; }
        public string ChatName { get; set; }
    }
}
