using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalSolution.EL;

namespace TechnicalSolution.DAL
{
    public class JobBoardDAL : RepositoryBase<JobBoard>
    {
        public JobBoardDAL(DataContext context) : base(context)
        {
        }

        public async Task InsertAsync(JobBoard entity)
        {
            await base.AddAsync(entity);
        }


        public async Task<JobBoard> ObtenerAsync()
        {
            return await base.FindAsync();
        }
    }
}
