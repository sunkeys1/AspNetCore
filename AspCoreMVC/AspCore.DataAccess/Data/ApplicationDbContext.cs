using AspCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCore.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UsersGroup { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "boris2020", Password = "123boris123", Created = DateTime.Now.AddDays(-2), GroupId = 2, UserState = "Active"},
                new User { Id = 2, Login = "superadmin", Password = "adminadmin1", Created = DateTime.Now.AddDays(-10), GroupId = 1, UserState = "Active" },
                new User { Id = 3, Login = "serejenka", Password = "imserge222", Created = DateTime.Now.AddDays(-3), GroupId = 2, UserState = "Blocked" }
                );
            modelBuilder.Entity<UserGroup>().HasData(
                new UserGroup { Id = 1, Code = "Active", Description = "CSGO Lovers", CreatedDate = DateTime.Now.AddDays(-2)},
                new UserGroup { Id = 2, Code = "Blocked", Description = "Data miners", CreatedDate = DateTime.Now.AddDays(-5)},
                new UserGroup { Id = 3, Code = "Super Active", Description = "Minecraft Enjoyers", CreatedDate = DateTime.Now.AddDays(-20)},
                new UserGroup { Id = 4, Code = "Active", Description = "Starcraft Koreans", CreatedDate = DateTime.Now.AddDays(-15)}

                );
        }
    }
}
