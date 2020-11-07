
using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces;
using AppTest.Domain.Interfaces.Repositoy;
using AppTest.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AppTest.Repository.Repositories
{
    public class ClienteRepository<TContext> : RepositoryBase<TContext, Cliente>, IClienteRepository<TContext>
       where TContext : IUnitOfWork<TContext>
    {
        private DbSet<Cliente> _dbSet => ((Contexts.AppTestContext)UnitOfWork).Set<Cliente>();

        public ClienteRepository(IUnitOfWork<TContext> context) : base(context) { }

        public Cliente ObterClientePorId(int clienteId)
        {
            return _dbSet.FirstOrDefault(cl => cl.ClienteId == clienteId);
        }
    }
}
