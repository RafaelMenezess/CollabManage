using CollabManage.Models;
using Microsoft.EntityFrameworkCore;

namespace CollabManage.Data;

public class CollabManageContext : DbContext
{
    public CollabManageContext(DbContextOptions<CollabManageContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employee { get; set; } = default!;
    public DbSet<Company> Company { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 1001,
            Name = "José",
            Cargo = "Desenvolvedor",
            Departamento = "Tecnologia"
        });
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 1002,
            Name = "Carlos",
            Cargo = "Analista",
            Departamento = "RH"
        });
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 1003,
            Name = "João",
            Cargo = "Vendedor",
            Departamento = "Comercial"
        });
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 1004,
            Name = "André",
            Cargo = "Suporte",
            Departamento = "Tecnologia"
        });
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 1005,
            Name = "Maria",
            Cargo = "Desenvolvedora",
            Departamento = "Tecnologia"
        });
        modelBuilder.Entity<Company>().HasData(new Company
        {
            Id = 2001,
            Name = "CollabManage",
            Endereco = "Br-116 - Fazenda Rio Grande",
            Telefone = "(41) 99123-4567",
        });
    }
}