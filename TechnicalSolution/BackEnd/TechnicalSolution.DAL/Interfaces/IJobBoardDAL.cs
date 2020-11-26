using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalSolution.EL;
using TechnicalSolution.EL.Configurations;

namespace TechnicalSolution.DAL.Interfaces
{

    public interface IJobBoardDAL
    {
        /// <summary>
        /// Add new record to database
        /// </summary>
        /// <param name="model">Object with the data to save</param>
        /// <returns>Task with information</returns>
        Task AddAsync(JobBoard model);

        /// <summary>
        /// Update a database record
        /// </summary>
        /// <param name="model">Object with the data to update</param>
        /// <returns>Task with information</returns>
        void Update(JobBoard model);

        /// <summary>
        /// Get a category belonging to the user.
        /// </summary>
        /// <param name = "id"> Id of the record to search for. </param>
        /// <returns> Result with the requested record. </returns>
        Task<JobBoard> FindByIdAsync(int id);

        /// <summary>
        /// Get all records from database
        /// </summary>
        /// <returns>Complete Data</returns>
        Task<IEnumerable<JobBoard>> GetAsync();

        /// <summary>
        /// delete a database record
        /// </summary>
        /// <param name="id">Object with id to delete</param>
        /// <returns>Task with information</returns>
        void Remove(JobBoard model);
    }
}
