using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace UDPServer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } // DbSet для таблицы Users
        public DbSet<Message> Messages { get; set; } // DbSet для таблицы Messages
        public DbSet<UserMessage> UserMessages { get; set; } // DbSet для таблицы UserMessages
        public DbSet<Chat> Chats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=HELES; Database=UserRegistrationDB; Trusted_Connection=True;");
            }
        }
    }
}
