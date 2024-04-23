using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Communication.Requests
{
    public class WalletRequest
    {
        public Guid Id { get; set; }
        public double Balance { get; set; }

    }
}
