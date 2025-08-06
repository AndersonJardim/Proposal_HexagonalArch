using ProjetoProposta.Domain.Exceptions;

namespace ProjetoProposta.Domain.Entities;

public sealed class Proposal
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public Proposal(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public void AddProposal(string name, string email)
    {
        Id = Guid.NewGuid();
        Validate(name, email);
        Name = name;
    }
    private static void Validate(string name, string email)
    {
        if (name is null || (name.Length < 3))
        {
            throw new InvalidNameException("Invalid Proposal Name");
        }
    }
}
