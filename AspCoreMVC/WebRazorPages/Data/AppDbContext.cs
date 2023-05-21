using Microsoft.EntityFrameworkCore;
using WebRazorPages.Models;

namespace WebRazorPages.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "boris2020razror", Password = "123boris123rz", Created = DateTime.Now.AddDays(-2), GroupId = 2, UserState = "Blocked" },
                new User { Id = 2, Login = "superadminrazor", Password = "adminadmin1rz", Created = DateTime.Now.AddDays(-10), GroupId = 1, UserState = "Active" },
                new User { Id = 3, Login = "serejenkarazor", Password = "imserge222rz", Created = DateTime.Now.AddDays(-3), GroupId = 2, UserState = "Blocked" }
                );
        }
    }
}
