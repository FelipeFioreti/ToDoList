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
        public DbSet<Token> Tokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<TaskModel>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Status>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Token>()
                .HasKey(u => u.Id);
        }
    }

}
