using Microsoft.EntityFrameworkCore;
namespace Model.Data
{
    public class TeploobmenContext:DbContext
    {
        public DbSet<Variants> Variants { get; set; }
        public TeploobmenContext(DbContextOptions<TeploobmenContext> options) : base(options) { }
    }
}
