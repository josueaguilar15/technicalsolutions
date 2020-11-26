using TechnicalSolution.DAL.Context;
using TechnicalSolution.DAL.Interfaces;
using TechnicalSolution.DAL.Repositories;
using TechnicalSolution.EL;

namespace TechnicalSolution.DAL.Implements
{
    /// <summary>
    /// IJobBoardDAL Implementation, You can add new methods, if you want to see the methods comments, you must place the cursor over the method, comments are inherited
    /// </summary>
    public class JobBoardDAL : RepositoryBase<JobBoard>, IJobBoardDAL
    {
        public JobBoardDAL(DataContext context) : base(context)
        {
        }
    }
}
