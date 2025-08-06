//using ProjetoProposta.Domain.Adapters;
using ProjetoProposta.Domain.Entities;
using ProjetoProposta.Domain.Ports;

namespace ProjetoProposta.Application.Services;

public class ProporsalServiceManager : IProposalService
{
    private readonly IProposalRepository _proposalRepository;

    public ProporsalServiceManager(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public async Task<IEnumerable<Proposal>> GetAllProposalsAsync()
    {
        var proposals = await _proposalRepository.GetAll();
        return proposals;
    }

    public async Task<Proposal> AddNewProposalAsync(Proposal proposal)
    {
        await _proposalRepository.Insert(proposal);
        //_emailAdapter.SendEmail("andersonjardim@gmail.com", "teste@email.com", "User was included with sucess...", "Added user");
        return proposal;
    }

    public async Task<Proposal> UpdateProposalAsync(Proposal proposal)
    {
        var proposalUpdated = await _proposalRepository.Update(proposal);
        //_emailAdapter.SendEmail("andersonjardim@gmail.com", "teste@email.com", "User was updated with sucess...", "Updated user");
        return proposalUpdated;
    }

    public async Task<Proposal> DeleteProposalAsync(Guid id)
    {
        var proposalDeleted = await _proposalRepository.Delete(id);
        //_emailAdapter.SendEmail("andersonjardim@gmail.com", "teste@email.com", "User was deleted with sucess...", "Deleted user");
        return proposalDeleted;
    }
}
