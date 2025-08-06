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
    public async Task<IActionResult> RegisterPropostal(Proposal proposal)
    {
        await _proposalService.AddNewProposalAsync(proposal);

        return Ok(proposal);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, Proposal proposal)
    {
        if (id != proposal.Id)
        {
            return BadRequest();
        }

        await _proposalService.UpdateProposalAsync(proposal);

        return Ok(proposal);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var user = await _proposalService.DeleteProposalAsync(id);

        return Ok(user);
    }
}
