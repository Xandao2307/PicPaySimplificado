using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PicPaySimplificado.Communication.Requests;
using PicPaySimplificado.Services.Services.Authorize.Exceptions;
using PicPaySimplificado.Services.Services.RabbitMqService;

namespace PicPaySimplificado.Services.Services.Notification
{
    public class NotificationService
    {
        private string _urlMock = "https://run.mocky.io/v3/54dc2cf1-3add-45b5-b5a9-6bf7e7f1f4a6";
        private ProducerService _producerService = new();
        private ConsumerServicer _consumerService = new();

        public async Task NotifyAll<T>(T model)
        {
            var jsonStrModel = JsonSerializer.Serialize(model);

            await _producerService.SendMenssage(jsonStrModel);

            var msgs = await _consumerService.ReadMenssages();

            foreach (var msg in msgs)
                await SendMenssageToMock(msg);
            

        }

        public async Task SendMenssageToMock(string msg)
        {

            using var client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(_urlMock);
                if (response.IsSuccessStatusCode)
                {
                    var json = JsonSerializer.Deserialize<ResponseHttp>(await response.Content.ReadAsStringAsync());

                    if (json != null || !json.message)
                        await SendMenssageToMock(msg);
                    else return;
                }
                else
                {
                    await SendMenssageToMock(msg);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private class ResponseHttp
        {
            public bool message { get; set; }
        }
    }
}
