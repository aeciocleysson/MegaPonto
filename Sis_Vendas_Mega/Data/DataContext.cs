using Microsoft.EntityFrameworkCore;
using Sis_Vendas_Mega.Data.Configuration;
using Sis_Vendas_Mega.Model;

namespace Sis_Vendas_Mega.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DbContext> options) : base(options) { }

        public DataContext() { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Model.Score> Scores { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<LogScore> LogScores { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("Host=192.168.0.60;Database=DbErpMega;Username=mega;Password=mega@3212");
            //optionsBuilder.UseMySql("Host=192.168.0.19;Database=DbErpMega;Username=mega;Password=mega@3212");
            optionsBuilder.UseMySql("Host=localhost;Database=DbErpMega;Username=root;Password=3103");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new FunctionConfiguration());
            modelBuilder.ApplyConfiguration(new LogScoreConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
