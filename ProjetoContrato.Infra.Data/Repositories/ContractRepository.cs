using Microsoft.EntityFrameworkCore;
using ProjetoContrato.Domain.Entities;
using ProjetoContrato.Domain.Ports;
using ProjetoContrato.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoContrato.Infra.Data.Repositories;

public class ContractRepository : IContractRepository
{
    public readonly ContratoAppDbContext _context;

    public ContractRepository(ContratoAppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Domain.Entities.Contract>> GetAll()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<Domain.Entities.Contract> Insert(Domain.Entities.Contract contract)
    {
        if (contract is null)
        {
            throw new ArgumentNullException(nameof(contract));
        }

        _context.Contracts.Add(contract);
        await _context.SaveChangesAsync();
        return contract;
    }
    public async Task<Domain.Entities.Contract> Update(Domain.Entities.Contract contract)
    {
        _context.Contracts.Update(contract);
        await _context.SaveChangesAsync();
        return contract;
    }
    public async Task<Domain.Entities.Contract> Delete(Guid id)
    {
        var contract = await _context.Contracts.FirstOrDefaultAsync(u => u.Id == id);

        if (contract is null)
        {
            throw new ArgumentNullException(nameof(contract));
        }

        _context.Contracts.Remove(contract);
        await _context.SaveChangesAsync();
        return contract;
    }
}
