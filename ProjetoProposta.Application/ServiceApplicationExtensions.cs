using Microsoft.Extensions.DependencyInjection;
using ProjetoProposta.Application.Services;
using ProjetoProposta.Domain.Ports;

namespace ProjetoProposta.Application;

public static class ServiceApplicationExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddTransient<IProposalService, ProporsalServiceManager>();
        return services;
    }
}
