using Microsoft.EntityFrameworkCore;
using AndyNetTest.Entities.UserInfo;

namespace AndyNetTest.Base.UserInfoContext
{
    public class UserInfoContext : DbContext
    {
        public UserInfoContext(DbContextOptions<UserInfoContext> options)
            : base(options)
        { }

        public DbSet<UserInfo> UserInfo { get; set; }
    }
}