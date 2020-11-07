using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces.Repositoy;
using System.Collections.Generic;

namespace AppTest.Domain.Interfaces.Service
{
    public interface IClienteService<TContext> : IServiceBase<TContext, Cliente>
        where TContext : IUnitOfWork<TContext>
    {
        Cliente ObterClientePorId(int clienteId);
    }
}