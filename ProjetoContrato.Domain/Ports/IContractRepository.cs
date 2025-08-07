using ProjetoContrato.Domain.Entities;

namespace ProjetoContrato.Domain.Ports;

public interface IContractRepository
{
    Task<IEnumerable<Contract>> GetAll();
    Task<Contract> Insert(Contract contract);
    Task<Contract> Update(Contract contract);
    Task<Contract> Delete(Guid id);
}
