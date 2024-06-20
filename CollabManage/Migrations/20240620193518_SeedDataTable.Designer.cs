﻿// <auto-generated />
using CollabManage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CollabManage.Migrations
{
    [DbContext(typeof(CollabManageContext))]
    [Migration("20240620193518_SeedDataTable")]
    partial class SeedDataTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CollabManage.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 2001,
                            Endereco = "Br-116 - Fazenda Rio Grande",
                            Name = "CollabManage",
                            Telefone = "(41) 99123-4567"
                        });
                });

            modelBuilder.Entity("CollabManage.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            Cargo = "Desenvolvedor",
                            Departamento = "Tecnologia",
                            Name = "José"
                        },
                        new
                        {
                            Id = 1002,
                            Cargo = "Analista",
                            Departamento = "RH",
                            Name = "Carlos"
                        },
                        new
                        {
                            Id = 1003,
                            Cargo = "Vendedor",
                            Departamento = "Comercial",
                            Name = "João"
                        },
                        new
                        {
                            Id = 1004,
                            Cargo = "Suporte",
                            Departamento = "Tecnologia",
                            Name = "André"
                        },
                        new
                        {
                            Id = 1005,
                            Cargo = "Desenvolvedora",
                            Departamento = "Tecnologia",
                            Name = "Maria"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
