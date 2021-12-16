using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_Vendas_Mega.Model;

namespace Sis_Vendas_Mega.Data.Configuration
{
    public class RegisterItensConfiguration : IEntityTypeConfiguration<RegisterItens>
    {
        public void Configure(EntityTypeBuilder<RegisterItens> builder)
        {
            builder.ToTable("RegisterItens");

            builder.Property(p => p.Quantidade);
            builder.Property(p => p.RegisterId);
        }
    }
}
