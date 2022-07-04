using System.Data.Entity;
using EntityFrameworkLayer6.Entities;

namespace EntityFrameworkLayer6.Context
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext() 
            : base("ProductManagementContextDB")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}