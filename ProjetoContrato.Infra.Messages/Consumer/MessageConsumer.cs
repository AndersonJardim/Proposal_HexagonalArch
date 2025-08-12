using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ProjetoContrato.Domain.Entities;
using ProjetoContrato.Domain.Ports;
using ProjetoContrato.Infra.Messages.Service;
using ProjetoContrato.Infra.Messages.Settings;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ProjetoContrato.Infra.Messages.Consumer
{
    public class MessageConsumer : BackgroundService
    {
        private readonly RabbitMqSettings _rabbitMqSettings;
        private readonly IServiceProvider _serviceProvider;

        public MessageConsumer(RabbitMqSettings rabbitMqSettings, IServiceProvider serviceProvider)
        {
            _rabbitMqSettings = rabbitMqSettings;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(_rabbitMqSettings.Url)
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            model.QueueDeclare(
                queue: _rabbitMqSettings.Queue,
                durable: true,
                autoDelete: false,
                exclusive: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(model);

            consumer.Received += async (sender, args) =>
            {
                var body = Encoding.UTF8.GetString(args.Body.ToArray());

                var message = JsonConvert.DeserializeObject<Contract>(body);

                using var scope = _serviceProvider.CreateScope();
                var contractRepository = scope.ServiceProvider.GetRequiredService<IContractRepository>();

                await contractRepository.Insert(message);

                model.BasicAck(args.DeliveryTag, false);
            };

            model.BasicConsume(_rabbitMqSettings.Queue, false, consumer);
        }
    }
}

