﻿using Microsoft.EntityFrameworkCore;
using WEB_API.Models;

namespace WEB_API.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Tasks> Tasks { get; set; }
    }
}
