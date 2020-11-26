using System;

namespace TechnicalSolution.DAL.Core
{
    public interface IDatabaseTransaction : IDisposable
    {
        /// <summary>
        /// Execute Commit to the database
        /// </summary>
        void Commit();
        /// <summary>
        /// Execute Rollback to the database
        /// </summary>
        void Rollback();
        /// <summary>
        /// Execute Dispose to the database
        /// </summary>
        void Dispose();
    }
}
