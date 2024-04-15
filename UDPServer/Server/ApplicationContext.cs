using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace TCPServer
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
                optionsBuilder.UseSqlServer(@"Data Source=HELES;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
