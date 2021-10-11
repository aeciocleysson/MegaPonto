using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sis_Vendas_Mega.Data.Configuration
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Model.Score>
    {
        public void Configure(EntityTypeBuilder<Model.Score> builder)
        {
            builder.ToTable("Score");

            builder.HasKey(w => w.Id);
            builder.Property(w => w.EntryTime);
            builder.Property(w => w.OutLanch);
            builder.Property(w => w.ReturnLunch);
            builder.Property(w => w.DepartureTime);
            builder.Property(w => w.Worked);

            builder.HasOne(p => p.Employee).WithMany(p => p.Scores).HasForeignKey(p => p.EmployeeId);

            builder.HasIndex(w => w.Id);
        }
    }
}
