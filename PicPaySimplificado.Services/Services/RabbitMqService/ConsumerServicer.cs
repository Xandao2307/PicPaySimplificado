using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.RabbitMqService
{
    public class ConsumerServicer
    {
        public async Task<IEnumerable<string>> ReadMenssages()
        {
            var (connection, channel) = ConfigurationRabbit.GetConnectionAndChannel();
            List<string> menssages = new List<string>();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var menssage = Encoding.UTF8.GetString(args.Body.ToArray());
                Console.WriteLine(menssage);
                menssages.Add(menssage);
            };

            channel.BasicConsume(queue: "Pic-Pay-Queue", autoAck: true, consumer: consumer);
            return menssages;
        }
    }
}
