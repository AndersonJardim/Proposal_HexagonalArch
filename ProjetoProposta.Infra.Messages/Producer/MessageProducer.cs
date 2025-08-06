using Newtonsoft.Json;
using ProjetoProposta.Infra.Messages.Settings;
using RabbitMQ.Client;
using System.Text;

namespace ProjetoProposta.Infra.Messages.Producer
{
    public class MessageProducer
    {
        private readonly RabbitMqSettings _rabbitMqSettings;

        public MessageProducer(RabbitMqSettings rabbitMqSettings)
        {
            _rabbitMqSettings = rabbitMqSettings;
        }

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_rabbitMqSettings.Url)
            };

            using var connection = factory.CreateConnection();
            using var model = connection.CreateModel();

            model.QueueDeclare(
                queue: _rabbitMqSettings.Queue,
                durable: true,
                autoDelete: false,
                exclusive: false,
                arguments: null
            );

            var jsonMessage = JsonConvert.SerializeObject( message );
            var body = Encoding.UTF8.GetBytes( jsonMessage );

            model.BasicPublish(
                exchange: string.Empty,
                routingKey: string.Empty,
                basicProperties: null,
                body: body
            );
        }
    }
}

