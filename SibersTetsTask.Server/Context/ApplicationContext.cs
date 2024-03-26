using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Model.Project;
using SibersTetsTask.Server.Model.ProjectTask;
using SibersTetsTask.Server.Model.User;
using System.Data;

namespace SibersTetsTask.Server.Context
{
    public class ApplicationContext : DbContext
    {
        public  DbSet<ProjectEntity> Projects { get; set; }  //add table Projects in DB
        public DbSet<EmployeeEntity> Employees { get; set; } // add table  Employees in DB
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ProjectTaskEntity> ProjectTasks { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options) 
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = 1, RoleName = "Employee" },
                new RoleEntity { Id = 2, RoleName = "Manager" },
                new RoleEntity { Id = 3, RoleName = "Director" }
            );
        }

    }
}
