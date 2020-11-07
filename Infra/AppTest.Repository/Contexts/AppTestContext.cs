
using AppTest.Domain.Interfaces;
using AppTest.Domain.Interfaces.Repositoy;
using AppTest.Repository.Maps;
using AppTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppTest.Repository.Contexts
{
    public class AppTestContext : DbContext, IUnitOfWork<AppTestContext>
    {
        public DbSet<Cliente> Clientes { get; set; }

        public AppTestContext(DbContextOptions<AppTestContext> options) : base(options) { }
        public int Commit() => this.SaveChanges();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteMap());            
        }
    }
}
