using Microsoft.EntityFrameworkCore;
using WebApiCreation.Models;

namespace WebApiCreation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Emp> emps { get; set; }

        public DbSet<User> users { get; set; }  
    }
}
