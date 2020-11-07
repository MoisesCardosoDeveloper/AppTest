using AppTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AppTest.Domain.Interfaces.Repositoy
{
    public interface IRepositoryBase<TContext, TEntity>
       where TEntity : EntityBase
       where TContext : IUnitOfWork<TContext>
    {
        TEntity Save(TEntity entity);
        void SaveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
    }
}
