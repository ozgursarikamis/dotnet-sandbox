using CQRS.Kafka.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Kafka.API.Database;

public class BankDbContext(DbContextOptions<BankDbContext> options) 
    : DbContext(options)
{
    public DbSet<Transaction> Transactions { get; set; }
}