using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sis_Vendas_Mega.Model;

namespace Sis_Vendas_Mega.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(w => w.Id);
            builder.Property(w => w.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(w => w.Code);
            builder.Property(w => w.DataNascimento).HasDefaultValue("01/01/1990");

            builder.HasIndex(w => w.Id);
            builder.HasOne(w => w.Function).WithMany(w => w.Employees).HasForeignKey(w => w.FunctionId);
        }
    }
}
