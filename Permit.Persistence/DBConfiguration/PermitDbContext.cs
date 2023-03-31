using Microsoft.EntityFrameworkCore;

namespace Permit.Persistence
{
    public class PermitDbContext : DbContext
    {
        public PermitDbContext(DbContextOptions<PermitDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PermitDbContext).Assembly);
        }
    }
}
