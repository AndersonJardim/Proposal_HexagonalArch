using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ProjetoContrato.Domain.Entities;
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

        public MessageConsumer(RabbitMqSettings rabbitMqSettings)
        {
            _rabbitMqSettings = rabbitMqSettings;
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

                await UpdateTeste.ConsumeMessage();

                model.BasicAck(args.DeliveryTag, false);
            };

            model.BasicConsume(_rabbitMqSettings.Queue, false, consumer);
        }
    }
}

