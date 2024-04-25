using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Infrasctructure.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsSeller { get; set; }
        public Wallet Wallet { get; set; }
        public IEnumerable<Transaction> TransactionsAsPayer { get; set; }
        public IEnumerable<Transaction> TransactionsAsPayee { get; set; }
    }

}
