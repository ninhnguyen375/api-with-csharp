using Microsoft.EntityFrameworkCore;

namespace APIWithDotNet.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("todo_item");
            modelBuilder.Entity<User>().ToTable("user");
            base.OnModelCreating(modelBuilder);
        }
    }
}