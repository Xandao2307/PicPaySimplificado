using PicPaySimplificado.Communication.Requests;
using PicPaySimplificado.Communication.Response;
using PicPaySimplificado.Infrasctructure.DbContexts;
using PicPaySimplificado.Infrasctructure.Entities;
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
        public async Task<TransactionResponse> Transfer(TransactionRequest transaction)
        {
            try
            {
                if (!await _transactionValidate.Validate(transaction))
                    throw new InvalidTransactionException("Invalidate Transaction");

                var walletPayee = _dbContext.Wallets.Where(w => w.UserId == transaction.Payee).First();
                var walletPayer = _dbContext.Wallets.Where(w => w.UserId == transaction.Payer).First();

                walletPayer.Balance -= transaction.Amount;
                walletPayee.Balance += transaction.Amount;

                Infrasctructure.Entities.Transaction trasaction = new()
                {
                    Amount = transaction.Amount,
                    DateTransaction = transaction.DateTransaction,
                    Id = transaction.Id,
                    Payee = await _dbContext.Users.FindAsync(transaction.Payee),
                    Payer = await _dbContext.Users.FindAsync(transaction.Payer),
                    PayeeId = transaction.Payee,
                    PayerId = transaction.Payer
                };

                await _dbContext.Transactions.AddAsync(trasaction);

                _notificationService.NotifyAll(transaction);

                await _dbContext.SaveChangesAsync();
                return new TransactionResponse() { Transaction = transaction, Message = "Transaction Made" };
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
