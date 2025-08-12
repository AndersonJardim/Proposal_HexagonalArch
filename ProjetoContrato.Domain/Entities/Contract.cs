using System.Diagnostics.CodeAnalysis;

namespace ProjetoContrato.Domain.Entities;

public sealed class Contract
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public int Status { get; private set; }

    // Construtor para criação de novos contratos
    public Contract(Guid id, string name, int status)
    {
        Id = id;
        Name = name;
        Status = status;
    }
}
