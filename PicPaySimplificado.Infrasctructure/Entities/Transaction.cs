using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Infrasctructure.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User Payee { get; set; }
        public User Payer { get; set; }
        public Guid PayeeId { get; set; }
        public Guid PayerId { get; set; }
        public double Amount { get; set; }
        public DateTime DateTransaction { get; set; }

    }
}
