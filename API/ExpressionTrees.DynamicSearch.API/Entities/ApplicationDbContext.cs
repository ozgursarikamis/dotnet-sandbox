using Microsoft.EntityFrameworkCore;

namespace ExpressionTrees.DynamicSearch.API.Entities;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
}