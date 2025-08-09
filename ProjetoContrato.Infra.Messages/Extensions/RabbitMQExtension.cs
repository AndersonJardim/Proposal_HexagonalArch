using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjetoContrato.Infra.Messages.Consumer;
using ProjetoContrato.Infra.Messages.Settings;

namespace ProjetoContrato.Infra.Messages.Extensions
{
    public static class RabbitMQExtension
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services,
            IConfiguration configuration)
        {
            var rabbitMqSettings = new RabbitMqSettings();

            new ConfigureFromConfigurationOptions<RabbitMqSettings>(configuration.GetSection("RabbitMQ"))
                .Configure(rabbitMqSettings);

            services.AddSingleton(rabbitMqSettings);
            services.AddHostedService<MessageConsumer>();

            return services;
        }
    }
}
