using Microsoft.EntityFrameworkCore;
using ProjetoProposta.Domain.Entities;

namespace ProjetoProposta.Infra.Data.Context;

public class PropostaAppDbContext : DbContext
{
    public PropostaAppDbContext(DbContextOptions<PropostaAppDbContext> options)
      : base(options)
    { }

    public DbSet<Proposal> Proposals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
