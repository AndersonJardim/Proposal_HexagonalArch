using ProjetoProposta.Domain.Entities;

namespace ProjetoProposta.Domain.Ports;

public interface IProposalRepository
{
    Task<IEnumerable<Proposal>> GetAll();
    Task<Proposal> Insert(Proposal proposal);
    Task<Proposal> Update(Proposal proposal);
    Task<Proposal> Delete(Guid id);
}
