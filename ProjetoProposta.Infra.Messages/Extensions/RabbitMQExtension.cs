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
            var rabbitMQSettings = new RabbitMqSettings();

            new ConfigureFromConfigurationOptions<RabbitMqSettings>(configuration.GetSection("RabbitMQ"))
                .Configure(rabbitMQSettings);

            services.AddSingleton(rabbitMQSettings);
            services.AddSingleton<MessageProducer>();

            return services;
        }
    }
}
