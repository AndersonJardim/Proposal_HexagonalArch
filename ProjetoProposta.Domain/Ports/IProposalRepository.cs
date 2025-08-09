using ProjetoProposta.Domain.Entities;

namespace ProjetoProposta.Domain.Ports;

public interface IProposalRepository
{
    Task<IEnumerable<Proposal>> GetAllAsync();
    Task<Proposal> InsertAsync(Proposal proposal);
    Task<Proposal> UpdateProposalAsync(Proposal proposal);
    Task<Proposal> DeleteAsync(Guid id);
}
