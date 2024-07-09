using Microsoft.EntityFrameworkCore;
using Model.Base;

namespace Infrastructure.Data;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    } 
    

