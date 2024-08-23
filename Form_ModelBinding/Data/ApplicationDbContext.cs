using Form_ModelBinding.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Form_ModelBinding.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Product> products {  get; set; } 
    }
}
