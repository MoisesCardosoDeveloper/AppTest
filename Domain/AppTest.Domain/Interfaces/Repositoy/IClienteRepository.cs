using AppTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AppTest.Domain.Interfaces.Repositoy
{
    public interface IClienteRepository<TContext> : IRepositoryBase<TContext, Cliente> 
        where TContext : IUnitOfWork<TContext>
    {
        Cliente ObterClientePorId(int clienteId);
    }
}
