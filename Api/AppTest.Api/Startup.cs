using AppTest.Api.Json;
using AppTest.IoC;
using AppTest.Repository.Contexts;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppTestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAutoMapper();
            AppTestIoC.Register(services);
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<AppTestContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                                         .ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning))
                                         .RalmsExtendFunctions());

            ServiceLocator.Init(services.BuildServiceProvider());
            

            services.AddMvcCore().AddAuthorization();

            services.AddMvc(options =>
            {
                
                
                options.RespectBrowserAcceptHeader = true;
             })
            .AddViewLocalization()
            .AddJsonOptions(x => DefaultJsonConfiguration.SetDefaultSerializerSettings(x.SerializerSettings));
        }



        // Esse método é chamado pelo tempo de execução. Use este método para configurar o pipeline de solicitação de HTTP.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            //UpdateDatabaseUsingEfCore(app);
        }

        //private void UpdateDatabaseUsingEfCore(IApplicationBuilder app)
        //{
        //    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        //    {
        //        serviceScope
        //            .ServiceProvider
        //            .GetRequiredService<AppTestContext>()
        //            .Database
        //            .Migrate();
        //    }
        //}
    }
}
