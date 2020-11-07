using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces.Repositoy;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AppTest.Domain.Interfaces.Service
{
    public interface IServiceBase<TContext, TEntity>
      where TContext : IUnitOfWork<TContext>
    {
        TEntity Save(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int chave);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);

        int Commit();
    }
}
