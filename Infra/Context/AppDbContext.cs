using Microsoft.EntityFrameworkCore;
using Domain;
using Infra.EntityMappingConfig;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }        
        public DbSet<Post> Posts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected AppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddModelConfiguration(modelBuilder);
        }

        private void AddModelConfiguration(ModelBuilder modelBuilder)
        {
        }
    }
}
