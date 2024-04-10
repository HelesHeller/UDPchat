using Microsoft.EntityFrameworkCore;

namespace Server
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=HELES; Database=UserRegistrationDB; Trusted_Connection=True;");
            }
        }
    }
}
