using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities.Models;

namespace ToDoListAPI.DataBase
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Status> Status { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<TaskModel>()
                .HasKey(u => u.TaskId);

            modelBuilder.Entity<Status>()
                .HasKey(u => u.StatusId);
        }
    }

}
