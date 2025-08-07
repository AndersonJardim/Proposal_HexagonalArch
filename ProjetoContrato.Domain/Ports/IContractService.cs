using ProjetoContrato.Domain.Entities;

namespace ProjetoContrato.Domain.Ports;

public interface IContractService
{
    Task<IEnumerable<Contract>> GetAllContractsAsync();
    Task<Contract> AddNewContractAsync(Contract contract);
    Task<Contract> UpdateContractAsync(Contract contract);
    Task<Contract> DeleteContractAsync(Guid id);
}
