using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.Transaction.Exceptions
{
    public class InvalidPayerException : Exception
    {
        public InvalidPayerException(string? message) : base(message)
        {
        }
    }
}
