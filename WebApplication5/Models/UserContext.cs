using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class UserContext : DbContext

    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) 

        {
            
        }
        public DbSet<Users> Users { get; set; }
    }
}
