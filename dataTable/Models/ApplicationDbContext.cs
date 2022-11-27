using Microsoft.EntityFrameworkCore;
using dataTable.Models;

namespace dataTable.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



       public  DbSet<Employee> employees { get; set; }



       public DbSet<dataTable.Models.Product> Product { get; set; }
    }
}
