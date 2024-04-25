using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.RabbitMqService
{
    public class ProducerService
    {
        public async Task SendMenssage(string menssage)
        {
            var (connection, channel) = ConfigurationRabbit.GetConnectionAndChannel();

            var body = Encoding.UTF8.GetBytes(menssage);

            // Envia a mensagem para a fila
            channel.BasicPublish(exchange: "",
                                 routingKey: "Pic-Pay-Queue",
                                 basicProperties: null,
                                 body: body);

        }
    }
}
