using Microsoft.EntityFrameworkCore;
using ToDoListDAL.Configure;
using ToDoListDAL.Entity;

namespace ToDoListDAL.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new RoleConfigure().Configure(modelBuilder.Entity<Role>());
            new UserConfigure().Configure(modelBuilder.Entity<User>());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
