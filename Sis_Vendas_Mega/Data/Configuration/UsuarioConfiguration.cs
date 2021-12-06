using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_Vendas_Mega.Model;

namespace Sis_Vendas_Mega.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(c => c.Nome).HasMaxLength(60);
            builder.Property(c => c.Login).HasMaxLength(20);
            builder.Property(c => c.Senha).HasMaxLength(20);
            builder.Property(c => c.NivelAcesso);

            builder.HasIndex(c => c.Id);
            builder.HasIndex(c => c.Nome);
        }
    }
}
