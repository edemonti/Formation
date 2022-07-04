using EntityFrameworkLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLayer
{
    public class MyEntities : DbContext
    {
        public MyEntities() : base("TaskConnection")
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
