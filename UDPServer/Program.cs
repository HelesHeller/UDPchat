using System;
using System.Linq;

namespace UDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext())
            {
                // Создание базы данных (если она еще не создана)
                db.Database.EnsureCreated();

                // Пример добавления нового пользователя
                var newUser = new User { Username = "user1", Password = "password1" };
                db.Users.Add(newUser);
                db.SaveChanges();

                // Пример выборки всех пользователей
                Console.WriteLine("All users:");
                foreach (var user in db.Users)
                {
                    Console.WriteLine($"{user.ID}: {user.Username}");
                }

                // Пример добавления нового чата
                var newChat = new Chat { Name = "General" };
                db.Chats.Add(newChat);
                db.SaveChanges();

                // Пример добавления нового сообщения
                var newMessage = new Message("Hello, world!", newUser.Username)
                {
                    Text = "Hello, world!",
                    SenderUsername = newUser.Username
                };

                db.Messages.Add(newMessage);
                db.SaveChanges();

                // Пример выборки всех сообщений в чате
                Console.WriteLine($"Messages in chat '{newChat.Name}':");
                foreach (var message in db.Messages)
                {
                    Console.WriteLine($"{message.Id}: {message.Text} ({message.Timestamp})");
                }
            }
        }
    }
}
