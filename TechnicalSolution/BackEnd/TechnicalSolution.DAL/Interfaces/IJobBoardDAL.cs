using System.Threading.Tasks;
using TechnicalSolution.EL;

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
    }
}
