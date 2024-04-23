using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.Transaction.Exceptions
{
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(string? message) : base(message)
        {
        }
    }
}
