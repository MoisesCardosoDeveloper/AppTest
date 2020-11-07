
using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces.Repositoy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AppTest.Repository
{
    public class RepositoryBase<TContext, TEntity> : IRepositoryBase<TContext, TEntity>
         where TEntity : EntityBase
         where TContext : IUnitOfWork<TContext>
    {
        protected IUnitOfWork<TContext> UnitOfWork { get; }

        public RepositoryBase(IUnitOfWork<TContext> unitOfWork) => this.UnitOfWork = unitOfWork;

        protected DbSet<TEntity> DbSet => ((DbContext)UnitOfWork).Set<TEntity>();

        public virtual TEntity Save(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public virtual void SaveRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual TEntity Update(TEntity entity)
        {
            var result = DbSet.Attach(entity);
            result.State = EntityState.Modified;
            return entity;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.AttachRange(entities);
        }

        public virtual void Delete(int id)
        {
            TEntity entity = Get(id);
            DbSet.Remove(entity);
        }

        public virtual TEntity Get(int id) => DbSet.Find(id);
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if(predicate == null)
                return DbSet.ToList();
            else
                return DbSet.Where(predicate).ToList();
        }
        public virtual ICollection<T> FromSql<T>(string sql, params object[] parameters) where T : class
        {
            var result = ((DbContext)UnitOfWork).Set<T>().FromSql(sql, parameters).ToList();

            return result;
        }
    }
}
