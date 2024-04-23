using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Communication.Requests
{
    public class TransactionRequest
    {
        public Guid Id { get; set; }
        public UserRequest Payee { get; set; }
        public UserRequest Payer { get; set; }
        public double Amount { get; set; }
        public DateTime DateTransaction { get; set; }
    }
}
