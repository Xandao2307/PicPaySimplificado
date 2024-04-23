using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.Transaction.Exceptions
{
    internal class WalletException : Exception
    {
        public WalletException(string? message) : base(message)
        {
        }
    }
}
