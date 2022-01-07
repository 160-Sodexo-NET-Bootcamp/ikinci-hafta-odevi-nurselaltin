using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Concrete.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options){} 
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
