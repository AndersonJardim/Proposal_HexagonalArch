using Microsoft.Extensions.DependencyInjection;
using ProjetoContrato.Application.Services;
using ProjetoContrato.Domain.Ports;

namespace ProjetoProposta.Application;

public static class ServiceApplicationExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddTransient<IContractService, ContractServiceManager>();
        return services;
    }
}
