using System.Threading.Tasks;
using TechnicalSolution.DAL.Context;
using TechnicalSolution.DAL.Implements;
using TechnicalSolution.DAL.Interfaces;

namespace TechnicalSolution.DAL.Core
{
    /// <summary>
    /// if you want to see the methods comments, you must place the cursor over the method, comments are inherited
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IJobBoardDAL _jobDAL;
        //DAL Interfaces Configurations
        public IJobBoardDAL JobBoard
        {
            get
            {
                return (_jobDAL ?? new JobBoardDAL(_context));
            }
        }

        public UnitOfWork(DataContext context) => _context = context;

        public async Task<int> Complete() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();

        public IDatabaseTransaction BeginTransaction() => new EntityDatabaseTransaction(_context);
    }
}
