
using AppTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTest.Repository.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente", "dbo");
            builder.HasKey(e => e.ClienteId);
            builder.Property(e => e.ClienteId);
            builder.Property(e => e.RazaoSocial).HasMaxLength(256);
            builder.Property(e => e.CNPJ).HasColumnName("CNPJ").HasMaxLength(18);
            builder.Property(e => e.Ativo);           
        }
    }
}
