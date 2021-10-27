using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_Vendas_Mega.Model;

namespace Sis_Vendas_Mega.Data.Configuration
{
    public class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable("Function");

            builder.Property(p => p.Description)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.HasIndex(w => w.Description);
        }
    }
}
