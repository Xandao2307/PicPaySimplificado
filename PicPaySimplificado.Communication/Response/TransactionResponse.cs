using PicPaySimplificado.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Communication.Response
{
    public class TransactionResponse
    {
        public string Message { get; set; }
        public TransactionRequest Transaction { get; set; }
    }
}
