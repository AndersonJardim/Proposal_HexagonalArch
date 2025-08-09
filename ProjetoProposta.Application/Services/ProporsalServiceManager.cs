//using ProjetoProposta.Domain.Adapters;
using ProjetoProposta.Domain.Entities;
using ProjetoProposta.Domain.Ports;
//ProjetoProposta.Domain.Ports;
using ProjetoProposta.Infra.Messages.Producer;

namespace ProjetoProposta.Application.Services;

public class ProporsalServiceManager : IProposalService
{
    private readonly IProposalRepository _proposalRepository;
    private readonly MessageProducer _messageProducer;

    public ProporsalServiceManager(IProposalRepository proposalRepository,
        MessageProducer messageProducer)
    {
        _proposalRepository = proposalRepository;
        _messageProducer = messageProducer;
    }

    public async Task<IEnumerable<Proposal>> GetAllProposalsAsync()
    {
        var proposals = await _proposalRepository.GetAllAsync();
        return proposals;
    }

    public async Task<Proposal> AddNewProposalAsync(Proposal proposal)
    {
        await _proposalRepository.InsertAsync(proposal);
        //_emailAdapter.SendEmail("andersonjardim@gmail.com", "teste@email.com", "User was included with sucess...", "Added user");

        if (proposal.Status == 1)
        {
            _messageProducer.SendMessage(proposal);
        };

        //_emailAdapter.SendEmail("andersonjardim@gmail.com", "teste@email.com", "User was included with sucess...", "Added user");
        return proposal;
    }

    public async Task<Proposal> UpdateProposalAsync(Proposal proposal)
    {
        var proposalUpdated = await _proposalRepository.UpdateProposalAsync(proposal);
        //_emailAdapter.SendEmail("andersonjardim@gmail.com", "teste@email.com", "User was updated with sucess...", "Updated user");

        if (proposalUpdated.Status == 1)
        {
            _messageProducer.SendMessage(proposalUpdated);
        }

        return proposalUpdated;
    }

    public async Task<Proposal> DeleteProposalAsync(Guid id)
    {
        var proposalDeleted = await _proposalRepository.DeleteAsync(id);
        //_emailAdapter.SendEmail("andersonjardim@gmail.com", "teste@email.com", "User was deleted with sucess...", "Deleted user");
        return proposalDeleted;
    }
}
