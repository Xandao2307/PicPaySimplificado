using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PicPaySimplificado.Communication.Requests
{
    public class TransactionRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Payee { get; set; }
        public Guid Payer { get; set; }
        public double Amount { get; set; }
        [JsonIgnore]
        public DateTime DateTransaction { get; set; } = DateTime.Now;
    }
}
