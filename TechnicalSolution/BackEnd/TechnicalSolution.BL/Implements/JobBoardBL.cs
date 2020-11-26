using System.Threading.Tasks;
using TechnicalSolution.BL.Interfaces;
using TechnicalSolution.DAL.Core;
using TechnicalSolution.EL;
using TechnicalSolution.EL.Configurations;

namespace TechnicalSolution.BL.Implements
{
    /// <summary>
    /// Implement IJobBoardBL Interface, if you want to see the methods comments, you must place the cursor over the method, comments are inherited
    /// </summary>
    public class JobBoardBL : IJobBoardBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobBoardBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BusinessValue<JobBoard>> AddAsync(JobBoard model)
        {
            await _unitOfWork.JobBoard.AddAsync(model);
            int affectedRows = await _unitOfWork.Complete();
            if (affectedRows == 0)
                return new BusinessValue<JobBoard>("An Error Ocurred to Insert JobBoard", Status.ERROR);
            return new BusinessValue<JobBoard>(model, "Good Insert", Status.OK);
        }

        //public async Task<BusinessValue<IEnumerable<JobBoard>>> GetAsync()
        //{
        //    var data = await _dalJobBoard.GetAsync();
        //    return new BusinessValue<IEnumerable<JobBoard>>(data, "JobBoards List", Status.OK);
        //}
    }
}
