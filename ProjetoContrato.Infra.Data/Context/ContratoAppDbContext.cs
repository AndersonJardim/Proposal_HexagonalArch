using Microsoft.EntityFrameworkCore;
using ProjetoContrato.Domain.Entities;

namespace ProjetoContrato.Infra.Data.Context;

public class ContratoAppDbContext : DbContext
{
  public ContratoAppDbContext(DbContextOptions<ContratoAppDbContext> options)
    : base(options)
  { }
  public DbSet<Contract> Contracts { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}
