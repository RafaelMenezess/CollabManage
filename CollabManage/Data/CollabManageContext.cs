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
}
