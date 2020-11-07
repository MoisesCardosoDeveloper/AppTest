using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces.Repositoy;
using AppTest.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AppTest.Domain.Services
{
    public class ServiceBase<TContexto, TEntity> : IServiceBase<TContexto, TEntity>
            where TEntity : EntityBase
            where TContexto : IUnitOfWork<TContexto>
    {
        protected readonly IRepositoryBase<TContexto, TEntity> _repository;
        protected readonly IUnitOfWork<TContexto> _unitOfWork;


        public ServiceBase(IRepositoryBase<TContexto, TEntity> repository, IUnitOfWork<TContexto> unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public virtual TEntity Save(TEntity entidade)
        {
            _repository.Save(entidade);
            return entidade;
        }

        public virtual TEntity Update(TEntity entidade)
        {
            _repository.Update(entidade);

            return entidade;
        }

        public virtual void Delete(int chave)
        {
            _repository.Delete(chave);
        }
        public virtual TEntity Get(int id) => _repository.Get(id);
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null) => _repository.GetAll(predicate);

        public int Commit()
        {
            return _unitOfWork.Commit();
        }
    }
}
