using Microsoft.EntityFrameworkCore;
using ProjetoProposta.Domain.Entities;
using ProjetoProposta.Domain.Ports;
using ProjetoProposta.Infra.Data.Context;

namespace ProjetoProposta.Infra.Data.Repositories;

public class ProposalRepository : IProposalRepository
{
    private readonly ProjetoProposta.Infra.Data.Context.PropostaAppDbContext _context;

    public ProposalRepository(ProjetoProposta.Infra.Data.Context.PropostaAppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Proposal>> GetAll()
    {
        return await _context.Proposals.ToListAsync();
    }

    public async Task<Proposal> Insert(Proposal proposal)
    {
        if (proposal is null)
        {
            throw new ArgumentNullException(nameof(proposal));
        }

        _context.Proposals.Add(proposal);
        await _context.SaveChangesAsync();
        return proposal;
    }
    public async Task<Proposal> Update(Proposal proposal)
    {
        _context.Proposals.Update(proposal);
        await _context.SaveChangesAsync();
        return proposal;
    }
    public async Task<Proposal> Delete(Guid id)
    {
        var proposal = await _context.Proposals.FirstOrDefaultAsync(u => u.Id == id);

        if (proposal is null)
        {
            throw new ArgumentNullException(nameof(proposal));
        }

        _context.Proposals.Remove(proposal);
        await _context.SaveChangesAsync();
        return proposal;
    }
}
