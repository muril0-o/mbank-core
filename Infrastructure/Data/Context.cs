using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}
    } 
    

