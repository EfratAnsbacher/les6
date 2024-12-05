using les3.Models;
using Microsoft.EntityFrameworkCore;


namespace les3.Repositories
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Attachments> Attachments { get; set; }
        public DbSet<Messages> Messages { get; set; }

    }
}
