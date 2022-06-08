using SM.DomainLayer.Core.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        void Add(TEntity entity);

        void AddSync(params TEntity[] entity);

        Task<TEntity> AddAsync(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        TEntity GetById(Expression<Func<TEntity, bool>> match);

        Task<TEntity> GetByIdAsync(object id);

        IQueryable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams);

        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate);

        Task<QueryResult<TEntity>> GetOrderedPageQueryResultAsync(QueryObjectParams queryObjectParams, IQueryable<TEntity> query);
        Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, List<Expression<Func<TEntity, object>>> includes);
        Task<QueryResult<TEntity>> GetPageAsync<TProperty>(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, TProperty>>> includes = null);

    }
}
