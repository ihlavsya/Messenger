using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Messenger.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Messenger.Domain.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        MessengerContext Context { get; set; }
        IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetAll();
        int Count();
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        //void Add(TEntity entity);
        //Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        //void DeleteRange(IEnumerable<TEntity> entities);
        void DeleteWhere(Expression<Func<TEntity, bool>> predicate);
        void Commit();
        Task CommitAsync();
        //void Attach(TEntity entity);
        //EntityEntry<TEntity> GetEntityEntry(TEntity entity);
    }
}
