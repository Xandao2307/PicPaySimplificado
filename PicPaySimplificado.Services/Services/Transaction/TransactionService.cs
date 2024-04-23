using PicPaySimplificado.Communication.Requests;
using PicPaySimplificado.Infrasctructure.DbContexts;
using PicPaySimplificado.Services.Services.Notification;
using PicPaySimplificado.Services.Services.Transaction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.Transaction
{
    public class TransactionService
    {
        private PicPayDbContext _dbContext { get; set; }
        private TransactionValidate _transactionValidate { get; set; }
        private NotificationService _notificationService { get; set; }
        public TransactionService(PicPayDbContext dbContext)
        {
            _dbContext = dbContext;
            _transactionValidate = new TransactionValidate(dbContext);
            _notificationService = new NotificationService();
        }
        public async Task Transfer(TransactionRequest transaction)
        {
            try
            {
                if (!await _transactionValidate.Validate(transaction))
                    throw new Exception("Invalidate Transaction");

                var walletPayee = _dbContext.Wallets.Where(w => w.UserId == transaction.Payee.Id).First();
                var walletPayer = _dbContext.Wallets.Where(w => w.UserId == transaction.Payer.Id).First();

                walletPayer.Balance -= transaction.Amount;
                walletPayee.Balance += transaction.Amount;

                _notificationService.NotifyAll(transaction);

                await _dbContext.SaveChangesAsync();
            }
            catch (InvalidPayerException e)
            {
                throw new InvalidTransactionException("Error with Payer: " + e.Message);

            }
            catch (WalletException e)
            {
                throw new InvalidTransactionException("Error with Wallet: " + e.Message);

            }

        }
    }
}
