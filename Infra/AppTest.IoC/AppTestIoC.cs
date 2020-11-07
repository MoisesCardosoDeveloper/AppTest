using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AppTest.Domain.Interfaces.Service;
using AppTest.Domain.Services;
using AppTest.Domain.Interfaces.Repositoy;
using AppTest.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using AppTest.Repository;
using AppTest.Repository.Repositories;

namespace AppTest.IoC
{
    public static class AppTestIoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork<AppTestContext>, AppTestContext>();
            services.AddTransient(typeof(IServiceBase<,>), typeof(ServiceBase<,>));
            services.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            // Cliente
            services.AddScoped(typeof(IClienteService<>), typeof(ClienteService<>));
            services.AddScoped(typeof(IClienteRepository<>), typeof(ClienteRepository<>));
        }

    }
}
