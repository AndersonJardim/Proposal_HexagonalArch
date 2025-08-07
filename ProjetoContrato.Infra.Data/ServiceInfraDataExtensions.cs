using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoContrato.Domain.Ports;
using ProjetoContrato.Infra.Data.Context;
using ProjetoContrato.Infra.Data.Repositories;

namespace ProjetoContrato.Infra.Data;

public static class ServiceInfraDataExtensions
{
    public static IServiceCollection AddDataBaseService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContratoAppDbContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IContractRepository, ContractRepository>();
        return services;
    }
}
