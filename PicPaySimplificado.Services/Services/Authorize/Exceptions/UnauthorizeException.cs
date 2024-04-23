using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.Authorize.Exceptions
{
    public class UnauthorizeException : Exception
    {
        public UnauthorizeException(string? message) : base(message)
        {
        }
    }
}
