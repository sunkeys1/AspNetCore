﻿using Microsoft.EntityFrameworkCore;
using WebApiNetCore.Data.Models;

namespace WebApiNetCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
