using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_Vendas_Mega.Model;

namespace Sis_Vendas_Mega.Data.Configuration
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.ToTable("Register");

            builder.Property(w => w.ProviderId);
        }
    }
}
