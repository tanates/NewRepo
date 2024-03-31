using Microsoft.EntityFrameworkCore;
using SibersTetsTask.Server.Model.ModelEntity.Project;
using SibersTetsTask.Server.Model.ModelEntity.ProjectTask;
using SibersTetsTask.Server.Model.ModelEntity.User;
using System.Data;

namespace SibersTetsTask.Server.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ProjectTaskEntity> ProjectTasks { get; set; }
        public DbSet<TaskEmployee> EmployeeTasks { get; set; }
        public DbSet<ManagerEntity> Managers { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = 1, RoleName = "Employee" },
                new RoleEntity { Id = 2, RoleName = "Manager" },
                new RoleEntity { Id = 3, RoleName = "Director" });

    
            /* modelBuilder.Entity<ProjectEntity>()
                .HasOne(p => p.ProjectManager)
                .WithMany(e => e.ManagedProjects)
                .HasForeignKey(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.SetNull);*/

         /*  modelBuilder.Entity<EmployeeProjectEntity>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.AuthoredTasks)
                .OnDelete(DeleteBehavior.NoAction);*/
            modelBuilder.Entity<ProjectTaskEntity>()
                .HasOne(p => p.Project)
                .WithMany(e => e.Tasks);
          
            modelBuilder.Entity<ProjectTaskEntity>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(pt => pt.ProjectId);






        }
    }
}
