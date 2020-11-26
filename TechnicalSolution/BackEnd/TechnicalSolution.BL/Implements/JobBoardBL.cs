using System.Collections.Generic;
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
                return new BusinessValue<JobBoard>("An error occurred while adding the record", Status.ERROR);
            return new BusinessValue<JobBoard>(model, "Succesful transaction.", Status.OK);
        }

        public async Task<BusinessValue<JobBoard>> Update(int id, JobBoard model)
        {
            model.Id = id;
            var entity = await _unitOfWork.JobBoard.FindByIdAsync(id);
            if (entity == null)
                return new BusinessValue<JobBoard>("JobBoard not found", Status.NOT_FOUND);
            _unitOfWork.JobBoard.Update(model);
            int affectedRows = await _unitOfWork.Complete();
            if (affectedRows == 0)
                return new BusinessValue<JobBoard>("An error occurred while updating the record", Status.ERROR);
            return new BusinessValue<JobBoard>(model, "Succesful transaction.", Status.OK);
        }

        public async Task<BusinessValue<JobBoard>> FindByIdAsync(int id)
        {
            var entity = await _unitOfWork.JobBoard.FindByIdAsync(id);
            if (entity == null)
                return new BusinessValue<JobBoard>("JobBoard not found", Status.NOT_FOUND);
            return new BusinessValue<JobBoard>(entity, "Succesful transaction.", Status.OK);
        }

        public async Task<BusinessValue<JobBoard>> Remove(int id)
        {
            var entity = await _unitOfWork.JobBoard.FindByIdAsync(id);
            if (entity == null)
                return new BusinessValue<JobBoard>("JobBoard not found", Status.NOT_FOUND);
            _unitOfWork.JobBoard.Remove(entity);
            int affectedRows = await _unitOfWork.Complete();
            if (affectedRows == 0)
                return new BusinessValue<JobBoard>("An error occurred while removing the record", Status.ERROR);
            return new BusinessValue<JobBoard>(entity, "Succesful transaction.", Status.OK);
        }

        public async Task<BusinessValue<IEnumerable<JobBoard>>> GetAsync()
        {
            var data = await _unitOfWork.JobBoard.GetAsync();
            return new BusinessValue<IEnumerable<JobBoard>>(data, "Succesful transaction.", Status.OK);
        }
    }
}
