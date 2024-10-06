using AppWebSpa.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebSpa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) 
        { 

        }

        public DbSet<User> Users { get; set; }
        public DbSet<SpaService> SpaServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpaService>().Property(
                s => s.Price).HasColumnType("decimal(38,2)");
        }

        
    }
}
