using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_Vendas_Mega.Model;

namespace Sis_Vendas_Mega.Data.Configuration
{
    public class HoursConfiguration : IEntityTypeConfiguration<Hours>
    {
        public void Configure(EntityTypeBuilder<Hours> builder)
        {
            builder.ToTable("Hours");

            builder.Property(p => p.Entry);
            builder.Property(p => p.Lunch);
            builder.Property(p => p.Exit);
            builder.Property(p => p.TotalWeek);
            builder.Property(p => p.TotalMonth);
        }
    }
}
