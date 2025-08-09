namespace ProjetoContrato.Domain.Entities;

public sealed class Contract
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public int Status { get; set; }
}
