using PicPaySimplificado.Communication.Requests;
using PicPaySimplificado.Infrasctructure.DbContexts;
using PicPaySimplificado.Services.Services.Authorize;
using PicPaySimplificado.Services.Services.Authorize.Exceptions;
using PicPaySimplificado.Services.Services.Transaction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.Transaction
{
    public class TransactionValidate
    {
        private PicPayDbContext _dbContext { get; set; }

        public TransactionValidate(PicPayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal async Task<bool> Validate(TransactionRequest transaction)
        {
            var payee = await _dbContext.Users.FindAsync(transaction.Payee);
            var payer = await _dbContext.Users.FindAsync(transaction.Payer);

            if (payee == null || payer == null || payer.IsSeller)
                throw new InvalidPayerException("The payer don't can be a seller");

            var walletPayer = _dbContext.Wallets.FirstOrDefault(w => w.UserId == payer.Id);
            if (walletPayer == null || walletPayer.Balance <= 0)
                throw new WalletException("Balance is insufficient");

            try
            {
                AuthorizeService authorizeService = new();
                var result = await authorizeService.Authorizer();
                return result;

            }
            catch (UnauthorizeException)
            {
                return false;
            }

        }
    }
}
