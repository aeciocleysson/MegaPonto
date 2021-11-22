using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_Vendas_Mega.Model;

namespace Sis_Vendas_Mega.Data.Configuration
{
    public class LogScoreConfiguration : IEntityTypeConfiguration<LogScore>
    {
        public void Configure(EntityTypeBuilder<LogScore> builder)
        {
            builder.ToTable("LogScore");

            builder.Property(p => p.Log);
            builder.Property(p => p.EmployeeId);

            builder.HasOne(w => w.Employee).WithMany(w => w.LogScores).HasForeignKey(w => w.EmployeeId);
        }
    }
}
