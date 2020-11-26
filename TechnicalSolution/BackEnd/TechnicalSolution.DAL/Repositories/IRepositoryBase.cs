using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TechnicalSolution.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get a list of entities.
        /// </summary>
        /// <param name = "filter"> Expression or filter to search for entities. </param>
        /// <param name = "orderBy"> Expression to order the list of entities. </param>
        /// <param name = "include"> Expression to include related entities. </param>
        /// <param name = "limit"> The maximum number of records to get. </param>
        /// <returns> A list of entities. </returns>

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Action<IQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int? limit = null);

        /// <summary>
        /// Obtain a list of entities asynchronously.
        /// </summary>
        /// <param name = "filter"> Expression or filter to search for entities. </param>
        /// <param name = "orderBy"> Expression to order the list of entities. </param>
        /// <param name = "include"> Expression to include related entities. </param>
        /// <param name = "limit"> The maximum number of records to get. </param>
        /// <returns> A list of entities. </returns>
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Action<IQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int? limit = null);

        /// <summary>
        /// Add an Entity.
        /// </summary>
        /// <param name = "entity"> Entity to be added. </param>
        void Add(TEntity entity);

        /// <summary>
        /// Asynchronously add an entity.
        /// </summary>
        /// <param name = "entity"> Entity to be added. </param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Add a list of entities.
        /// </summary>
        /// <param name = "entityList"> List of entities to be added. </param>
        void AddRange(IEnumerable<TEntity> entityList);

        /// <summary>
        /// Add a list of entities asynchronously.
        /// </summary>
        /// <param name = "entityList"> List of entities to be added. </param>
        Task AddRangeAsync(IEnumerable<TEntity> entityList);

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name = "entity"> The entity to update. </param>
        void Update(TEntity entity);

        /// <summary>
        /// Update a list of entities.
        /// </summary>
        /// <param name = "entityList"> The list of entities to update. </param>
        void UpdateRange(IEnumerable<TEntity> entityList);

        /// <summary>
        /// Remove an entity.
        /// </summary>
        /// <param name = "entity"> The entity to remove. </param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove a list of entities.
        /// </summary>
        /// <param name = "entityList"> The list of entities to be removed. </param>
        void RemoveRange(IEnumerable<TEntity> entityList);
    }
}
