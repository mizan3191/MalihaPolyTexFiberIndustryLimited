using Microsoft.EntityFrameworkCore;

namespace MalihaPolyTex.Web.Models.Demo
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<MainProduct> MainProduct { get; set; }
    }
}