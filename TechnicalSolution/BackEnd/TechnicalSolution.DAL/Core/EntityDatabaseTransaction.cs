using Microsoft.EntityFrameworkCore.Storage;
using TechnicalSolution.DAL.Context;

namespace TechnicalSolution.DAL.Core
{
    /// <summary>
    /// Handles transactions to the database, if you want to see the methods comments, you must place the cursor over the method, comments are inherited
    /// </summary>
    public class EntityDatabaseTransaction : IDatabaseTransaction
    {
        private readonly IDbContextTransaction _transaction;

        public EntityDatabaseTransaction(DataContext context) => _transaction = context.Database.BeginTransaction();

        public void Commit() => _transaction.Commit();
        public void Rollback() => _transaction.Rollback();
        public void Dispose() => _transaction.Dispose();

    }
}
