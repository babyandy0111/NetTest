using Microsoft.EntityFrameworkCore;
using Snai.Mysql.Entities;

namespace AndyNetTest.Base
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Users> User { get; set; }
    }
}