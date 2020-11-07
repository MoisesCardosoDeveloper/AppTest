using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Domain.Interfaces.Repositoy
{
    public interface IUnitOfWork<TContext>
    {
        int Commit();
    }
}
