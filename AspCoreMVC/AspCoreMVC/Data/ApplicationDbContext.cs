using AspCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "boris2020", Password = "123boris123", Created = DateTime.Now.AddDays(-2), GroupId = 2, UserState = "Active"},
                new User { Id = 2, Login = "superadmin", Password = "adminadmin1", Created = DateTime.Now.AddDays(-10), GroupId = 1, UserState = "Active" },
                new User { Id = 3, Login = "serejenka", Password = "imserge222", Created = DateTime.Now.AddDays(-3), GroupId = 2, UserState = "Blocked" }
                );
        }
    }
}
