using ProjetoContrato.Domain.Entities;
using ProjetoContrato.Domain.Ports;
////using ProjetoContrato.Infra.Messages.Producer;

namespace ProjetoContrato.Application.Services;

public class ContractServiceManager : IContractService
{
    private readonly IContractRepository _contractRepository;
    public ContractServiceManager(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<IEnumerable<Contract>> GetAllContractsAsync()
    {
        var contracts = await _contractRepository.GetAll();
        return contracts;
    }

    public async Task<Contract> AddNewContractAsync(Domain.Entities.Contract contract)
    {
        await _contractRepository.Insert(contract);
        return contract;
    }

    public Task<Contract> UpdateContractAsync(Domain.Entities.Contract contract)
    {
        var contractUpdated = _contractRepository.Update(contract);
        return contractUpdated;
    }

    public Task<Contract> DeleteContractAsync(Guid id)
    {
        var contractDeleted = _contractRepository.Delete(id);
        return contractDeleted;
    }
}
