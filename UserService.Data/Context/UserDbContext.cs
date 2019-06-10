using System;
using System.Collections.Generic;
using System.Text;
using ExampleMicroservices.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using UserService.Data.Models;

namespace UserService.Data.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
        {
            
        }

        public UserDbContext(DbContextOptions<UserDbContext> dbContext)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL(ConnectionExtensions.GetConnectionString());
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
