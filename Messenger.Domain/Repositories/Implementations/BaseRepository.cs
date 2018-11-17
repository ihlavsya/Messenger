using Messenger.Domain.Models;
using Messenger.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Messenger.Domain.Repositories.Implementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly MessengerContext context;
        public MessengerContext Context { get; set; }

        #region Properties

        public BaseRepository(MessengerContext context)
        {
            this.context = context;
            this.Context = context;
        }

        #endregion

        public virtual IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        public virtual int Count()
        {
            return context.Set<TEntity>().Count();
        }

        public virtual IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsQueryable();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            //EntityEntry dbEntityEntry = context.Entry<TEntity>(entity);
            await context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            EntityEntry dbEntityEntry = context.Entry<TEntity>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            EntityEntry dbEntityEntry = context.Entry<TEntity>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> entities = context.Set<TEntity>().Where(predicate);

            foreach (var entity in entities)
            {
                context.Entry<TEntity>(entity).State = EntityState.Deleted;
            }
        }

        public virtual void Commit()
        {
            context.SaveChanges();
        }
        public virtual async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
