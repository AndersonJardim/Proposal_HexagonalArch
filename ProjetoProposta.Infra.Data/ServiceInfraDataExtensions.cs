using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoProposta.Domain.Ports;
using ProjetoProposta.Infra.Data.Context;
using ProjetoProposta.Infra.Data.Repositories;

namespace ProjetoProposta.Infra.Data;

public static class ServiceInfraDataExtensions
{
    public static IServiceCollection AddDataBaseService(this IServiceCollection services, IConfiguration configuration)
    {
        var teste = configuration.GetSection("RabbitMqSettings");
        services.AddDbContext<PropostaAppDbContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IProposalRepository, ProposalRepository>();
        return services;
    }
}
