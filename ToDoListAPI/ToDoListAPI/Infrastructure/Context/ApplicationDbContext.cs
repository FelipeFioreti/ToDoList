using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
