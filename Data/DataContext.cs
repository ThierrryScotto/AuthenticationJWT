using AuthenticationJWT.models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationJWT.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}