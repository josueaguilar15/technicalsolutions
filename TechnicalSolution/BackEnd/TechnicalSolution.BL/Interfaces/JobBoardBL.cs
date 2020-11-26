using System.Threading.Tasks;
using TechnicalSolution.EL;
using TechnicalSolution.EL.Configurations;

namespace TechnicalSolution.BL.Interfaces
{
    public interface IJobBoardBL
    {
        /// <summary>
        /// Invoke DAL.AddAssync to Add a new record
        /// </summary>
        /// <param name="model">Object with the data to save </param>
        /// <returns>Custom object with transaction status and information</returns>
        Task<BusinessValue<JobBoard>> AddAsync(JobBoard model);
    }
}
