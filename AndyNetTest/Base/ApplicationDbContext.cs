using Microsoft.EntityFrameworkCore;
using AndyNetTest.Entities.Users;
using AndyNetTest.Entities.UserInfo;

namespace AndyNetTest.Base.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Users> User { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}