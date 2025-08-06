using ProjetoProposta.Domain.Entities;

namespace ProjetoProposta.Domain.Ports;

public interface IProposalService
{
    Task<IEnumerable<Proposal>> GetAllProposalsAsync();
    Task<Proposal> AddNewProposalAsync(Proposal proposal);
    Task<Proposal> UpdateProposalAsync(Proposal proposal);
    Task<Proposal> DeleteProposalAsync(Guid id);
}
