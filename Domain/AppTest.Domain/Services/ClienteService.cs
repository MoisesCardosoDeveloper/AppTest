using AppTest.Domain.Services;
using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces.Repositoy;
using AppTest.Domain.Interfaces.Service;

namespace AppTest.Domain.Services
{
    public class ClienteService<TContext> : ServiceBase<TContext, Cliente>, IClienteService<TContext>
         where TContext : IUnitOfWork<TContext>
    {
        private readonly IClienteRepository<TContext> _repository;

        public ClienteService(IClienteRepository<TContext> repository, IUnitOfWork<TContext> unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
        }

        public Cliente ObterClientePorId(int clienteId)
        {

            _repository.GetAll(x=> x.Ativo == true && x.ClienteId == 10);
                           return _repository.ObterClientePorId(clienteId);
        }
    }
}