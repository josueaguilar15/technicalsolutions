using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalSolution.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Buscar una entidad.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar la entidad.</param>
        /// <param name="include">Expresión para incluir entidades relacionadas.</param>
        /// <returns>La entidad encontrada.</returns>
        TEntity Find(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Buscar una entidad.
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns>La entidad encontrada.</returns>
        TEntity Find(params object[] keyValues);

        /// <summary>
        /// Buscar de forma asíncrona una entidad.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar la entidad.</param>
        /// <param name="include">Expresión para incluir entidades relacionadas.</param>
        /// <returns>La entidad encontrada.</returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Buscar de forma asíncrona una entidad.
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns>La entidad encontrada.</returns>
        Task<TEntity> FindAsync(params object[] keyValues);

        /// <summary>
        /// Obtener un listado de entidades.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar las entidades.</param>
        /// <param name="orderBy">Expresión para ordenar el listado de entidades.</param>
        /// <param name="include">Expresión para incluir las entidades relacionadas.</param>
        /// <param name="limit">La cantidad máxima de registros que se desea obtener.</param>
        /// <returns>Un listado de entidades.</returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Action<IQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int? limit = null);

        /// <summary>
        /// Obtener de forma asíncrona un listado de entidades.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar las entidades.</param>
        /// <param name="orderBy">Expresión para ordenar el listado de entidades.</param>
        /// <param name="include">Expresión para incluir las entidades relacionadas.</param>
        /// <param name="limit">La cantidad máxima de registros que se desea obtener.</param>
        /// <returns>Un listado de entidades.</returns>
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Action<IQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int? limit = null);

        /// <summary>
        /// Encontrar la primer entidad.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar la entidad.</param>
        /// <param name="include">Expresión para incluir entidades relacionadas.</param>
        /// <returns>La primera entidad encontrada, y si no encuenta nada retorna <c>null</c>.</returns>
        TEntity FindFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Encontrar de forma asíncrona la primer entidad.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar la entidad.</param>
        /// <param name="include">Expresión para incluir entidades relacionadas.</param>
        /// <returns>La primera entidad encontrada, y si no encuenta nada retorna <c>null</c>.</returns>
        Task<TEntity> FindFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Encontrar la última entidad.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar la entidad.</param>
        /// <param name="include">Expresión para incluir entidades relacionadas.</param>
        /// <returns>La última entidad encontrada, y si no encuenta nada retorna <c>null</c>.</returns>
        TEntity FindLastOrDefault(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Encontrar de forma asíncrona la última entidad.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar la entidad.</param>
        /// <param name="include">Expresión para incluir entidades relacionadas.</param>
        /// <returns>La última entidad encontrada, y si no encuenta nada retorna <c>null</c>.</returns>
        Task<TEntity> FindLastOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        /// <summary>
        /// Agregar una Entidad.
        /// </summary>
        /// <param name="entity">Entidad que se quiere agregar.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Agregar de forma asíncrona una entidad.
        /// </summary>
        /// <param name="entity">Entidad que se agregará.</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Agregar un listado de entidades.
        /// </summary>
        /// <param name="entityList">Listado de entidades que se agregarán.</param>
        /// <returns></returns>
        void AddRange(IEnumerable<TEntity> entityList);

        /// <summary>
        /// Agregar de forma asíncrona un listado de entidades.
        /// </summary>
        /// <param name="entityList">Listado de entidades que se agregarán.</param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<TEntity> entityList);

        /// <summary>
        /// Actualizar una entidad.
        /// </summary>
        /// <param name="entity">La entidad que se actualizará.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Actualizar un listado de entidades.
        /// </summary>
        /// <param name="entityList">El listado de entidades que se actualizará.</param>
        void UpdateRange(IEnumerable<TEntity> entityList);

        /// <summary>
        /// Remover una entidad.
        /// </summary>
        /// <param name="entity">La entidad que se eliminará.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remover un listado de entidades.
        /// </summary>
        /// <param name="entityList">El listado de entidades que se eliminarán.</param>
        void RemoveRange(IEnumerable<TEntity> entityList);

        /// <summary>
        /// Verificar si la entidad existe.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar la entidad.</param>
        /// <returns><c>true</c> si existe, o <c>false</c> si no existe.</returns>
        bool Any(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Verificar de forma asíncrona si la entidad existe.
        /// </summary>
        /// <param name="filter">Expresión o filtro para buscar la entidad.</param>
        /// <returns><c>true</c> si existe, o <c>false</c> si no existe.</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Contar las entidades.
        /// </summary>
        /// <param name="filter">Expresión o filtro para contar las entidades.</param>
        /// <returns>La cantidad de entidades encontradas.</returns>
        int Count(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Contar de forma asíncrona las entidades.
        /// </summary>
        /// <param name="filter">Expresión o filtro para contar las entidades.</param>
        /// <returns>La cantidad de entidades encontradas.</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}
