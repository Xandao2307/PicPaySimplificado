using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.RabbitMqService
{
    public class ConfigurationRabbit
    {
        private static IConnection? Connection { get; set; }
        private static IModel? Channel { get; set; }

        public ConfigurationRabbit()
        {
            GetConnectionAndChannel();
        }
        public static (IConnection, IModel) GetConnectionAndChannel()
        {
            if (Connection != null && Channel != null)
                return (Connection, Channel);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (Connection = factory.CreateConnection())
            using (Channel = Connection.CreateModel())
            {
                Channel.QueueDeclare(queue: "Pic-Pay-Queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
                
                return (Connection, Channel);
            }
        }
    }
}
