using Microsoft.EntityFrameworkCore;
using TechnicalSolution.EL;

namespace TechnicalSolution.DAL.Context
{
    /// <summary>
    /// DbContext or conection BD
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        
        public DbSet<JobBoard> JobBoard { get; set; }

        /// <summary>
        /// Table mapping for database
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobBoard>().ToTable("JobBoard");
        }
    }
}
