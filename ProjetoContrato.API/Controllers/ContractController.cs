using Microsoft.AspNetCore.Mvc;
using ProjetoContrato.Domain.Entities;
using ProjetoContrato.Domain.Ports;

namespace ProjetoContrato.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    private readonly IContractService _contractService;
    public ContractController(IContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contracts = await _contractService.GetAllContractsAsync();
        return Ok(contracts);
    }


    [HttpPost]
    public async Task<IActionResult> Register(Contract contract)
    {
        if (contract == null)
        {
            return BadRequest("Contract data is required.");
        }
        //var createdContract = await _contractService.CreateContractAsync(contractDto);
        //return CreatedAtAction(nameof(GetAll), new { id = createdContract.Id }, createdContract);

        await _contractService.AddNewContractAsync(contract);
        return Ok(contract);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, Contract contract)
    {
        if (id != contract.Id)
        {
            return BadRequest();
        }

        await _contractService.UpdateContractAsync(contract);
        if (contract == null)
        {
            return NotFound($"Contract with ID {id} not found.");
        }
        return Ok(contract);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        //var contract = await _contractService.GetContractByIdAsync(id);
        //if (contract == null)
        //{
        //    return NotFound($"Contract with ID {id} not found.");
        //}
        //await _contractService.DeleteContractAsync(id);
        //return NoContent();

        var contract = await _contractService.DeleteContractAsync(id);
        return Ok(contract);
    }



}
