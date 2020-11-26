using System;
using System.Threading.Tasks;
using TechnicalSolution.DAL.Interfaces;

namespace TechnicalSolution.DAL.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //Declare Data Access Data Interfaces
        IJobBoardDAL JobBoard { get; }

        /// <summary>
        /// Start transactions to the database
        /// </summary>
        IDatabaseTransaction BeginTransaction();

        /// <summary>
        /// Invoke Commit to the database
        /// </summary>
        Task<int> Complete();
    }
}
