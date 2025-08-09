using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjetoProposta.Infra.Messages.Producer;
using ProjetoProposta.Infra.Messages.Settings;

namespace ProjetoProposta.Infra.Messages.Extensions
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
            services.AddSingleton<MessageProducer>();

            return services;
        }
    }
}
