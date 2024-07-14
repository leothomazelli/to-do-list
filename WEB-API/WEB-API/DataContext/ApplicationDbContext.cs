using Microsoft.EntityFrameworkCore;
using WEB_API.DataContext.Extensions;
using WEB_API.Models;

namespace WEB_API.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<User> User { get; set; }

        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyGlobalConfiguration();
            base.OnModelCreating(modelBuilder);
        }
    }
}
