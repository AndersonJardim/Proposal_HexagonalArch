using Microsoft.AspNetCore.Mvc;
using ProjetoProposta.Domain.Entities;
using ProjetoProposta.Domain.Ports;

namespace ProjetoPropostal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropostaController : ControllerBase
{
    private readonly IProposalService _proposalService;

    public PropostaController(IProposalService proposalService)
    {
        _proposalService = proposalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPropostals()
    {
        var proposal = await _proposalService.GetAllProposalsAsync();

        return Ok(proposal);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterPropostal(ProposalInsert proposal)
    {
        try
        {
            await _proposalService.AddNewProposalAsync(new Proposal
            {
                Name = proposal.Name,
                Status = proposal.Status
            });

            return Ok(proposal);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProposalAsync(Proposal proposal)
    {
        try
        {
            if (proposal.Id is null)
            {
                return BadRequest("Id não pode ser nulo.");
            }

            await _proposalService.UpdateProposalAsync(proposal);

            return Ok(proposal);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] Guid id)
    {
        var user = await _proposalService.DeleteProposalAsync(id);

        return Ok(user);
    }
}
