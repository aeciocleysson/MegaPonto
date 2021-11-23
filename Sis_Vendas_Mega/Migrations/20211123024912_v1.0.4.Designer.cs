﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sis_Vendas_Mega.Data;

namespace Sis_Vendas_Mega.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211123024912_v1.0.4")]
    partial class v104
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sis_Vendas_Mega.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<string>("DataNascimento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValue("01/01/1990");

                    b.Property<int>("FunctionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Sis_Vendas_Mega.Model.Function", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Description");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("Sis_Vendas_Mega.Model.Hours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Entry")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("Exit")
                        .HasColumnType("time(6)");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Lunch")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("TotalMonth")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("TotalWeek")
                        .HasColumnType("time(6)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Hours");
                });

            modelBuilder.Entity("Sis_Vendas_Mega.Model.LogScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<int>("Log")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("LogScore");
                });

            modelBuilder.Entity("Sis_Vendas_Mega.Model.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("FullRange")
                        .HasColumnType("time(6)");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<double>("Minutes")
                        .HasColumnType("double");

                    b.Property<DateTime>("OutLanch")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ReturnLunch")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("Worked")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("Id");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("Sis_Vendas_Mega.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Tipo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("Nome");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Sis_Vendas_Mega.Model.Employee", b =>
                {
                    b.HasOne("Sis_Vendas_Mega.Model.Function", "Function")
                        .WithMany("Employees")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sis_Vendas_Mega.Model.LogScore", b =>
                {
                    b.HasOne("Sis_Vendas_Mega.Model.Employee", "Employee")
                        .WithMany("LogScores")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sis_Vendas_Mega.Model.Score", b =>
                {
                    b.HasOne("Sis_Vendas_Mega.Model.Employee", "Employee")
                        .WithMany("Scores")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}