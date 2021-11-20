﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Host=192.168.0.19;Database=DbErpMega;Username=mega;Password=mega@3212");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new FunctionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
