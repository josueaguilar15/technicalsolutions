using Microsoft.EntityFrameworkCore;
using TechnicalSolution.EL;

namespace TechnicalSolution.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<JobBoard> JobBoard { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobBoard>().ToTable("JobBoard");
        }
    }
}
