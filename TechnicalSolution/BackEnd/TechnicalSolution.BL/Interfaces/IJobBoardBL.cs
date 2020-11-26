using System.Collections;
using System.Collections.Generic;
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

        /// <summary>
        /// Invoke DAL.UpdateAsync to update a record
        /// </summary>
        /// <param name="model">Object with the data to update</param>
        /// <returns>Custom object with transaction status and information</returns>
        Task<BusinessValue<JobBoard>> Update(int id, JobBoard model);

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <returns>Complete Data</returns>
        Task<BusinessValue<IEnumerable<JobBoard>>> GetAsync();

        /// <summary>
        /// Invoke DAL.Remove to delete a record
        /// </summary>
        /// <param name="model">Object with the data to delete</param>
        /// <returns>Custom object with transaction status and information</returns>
        Task<BusinessValue<JobBoard>> Remove(int id);

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns>Record found</returns>
        Task<BusinessValue<JobBoard>> FindByIdAsync(int id);
    }
}
