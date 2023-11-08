using Microsoft.EntityFrameworkCore;
using MNSBI2.Core.Models;

namespace MNSBI2.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BIView> BIViews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here if needed.
        }
    }
}