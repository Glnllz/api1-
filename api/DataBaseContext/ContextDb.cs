
using api1.Model;
using Microsoft.EntityFrameworkCore;

namespace api1.DataBaseContext
{
    public class ContextDb : DbContext
    {

        public ContextDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet <Users> Users { get; set; }
        public DbSet <Logins> Logins { get; set; }
        public DbSet<Role> Role { get; set; }


    }
}
