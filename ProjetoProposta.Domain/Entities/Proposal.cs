using ProjetoProposta.Domain.Exceptions;

namespace ProjetoProposta.Domain.Entities;

public sealed class Proposal
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Status { get; set; }
}
