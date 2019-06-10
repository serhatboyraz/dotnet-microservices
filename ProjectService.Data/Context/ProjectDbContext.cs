using ExampleMicroservices.Utils.Extensions;
using Microsoft.EntityFrameworkCore;
using ProjectService.Data.Models;

namespace ProjectService.Data.Context
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {
            
        }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> dbContext)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL(ConnectionExtensions.GetConnectionString());
        }

        public DbSet<ProjectModel> Project { get; set; }
        public DbSet<ProjectRoleModel> ProjectRole { get; set; }

    }
}
