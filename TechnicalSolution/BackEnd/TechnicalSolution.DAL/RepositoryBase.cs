using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalSolution.DAL
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _ctx;
        internal DbSet<TEntity> dbSet;

        public RepositoryBase(DbContext context)
        {
            this._ctx = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entityList)
        {
            dbSet.AddRange(entityList);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entityList)
        {
            await dbSet.AddRangeAsync(entityList);
        }

        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            return dbSet.Any(filter);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await dbSet.AnyAsync(filter);
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return dbSet.Count(filter);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await dbSet.CountAsync(filter);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);
            return query.SingleOrDefault();
        }

        public TEntity Find(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);
            return await query.SingleOrDefaultAsync();
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await dbSet.FindAsync(keyValues);
        }

        public TEntity FindFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);
            return query.FirstOrDefault();
        }

        public async Task<TEntity> FindFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);
            return await query.FirstOrDefaultAsync();
        }

        public TEntity FindLastOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);
            return query.LastOrDefault();
        }

        public async Task<TEntity> FindLastOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);
            return await query.LastOrDefaultAsync();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Action<IQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int? limit = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);
            if (orderBy != null)
                orderBy.Invoke(query);
            if (limit.HasValue)
                query = query.Take(limit.Value);
            return query.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Action<IQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int? limit = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);
            if (orderBy != null)
                orderBy.Invoke(query);
            if (limit.HasValue)
                query = query.Take(limit.Value);
            return await query.ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entityList)
        {
            dbSet.RemoveRange(entityList);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entityList)
        {
            dbSet.UpdateRange(entityList);
        }
    }
}
