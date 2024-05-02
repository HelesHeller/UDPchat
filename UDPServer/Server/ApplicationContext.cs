using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Diagnostics.Metrics;


namespace TCPServer
{
    public  class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } // DbSet для таблицы Users
        public DbSet<Message> Messages { get; set; } // DbSet для таблицы Messages
        public DbSet<UserMessage> UserMessages { get; set; } // DbSet для таблицы UserMessages
        public DbSet<Chat> Chats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HELES; Database=DZ_29_01; Trusted_Connection=True; TrustServerCertificate=True; Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
