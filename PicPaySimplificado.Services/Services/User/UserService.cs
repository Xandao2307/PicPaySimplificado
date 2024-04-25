using Microsoft.EntityFrameworkCore.Query.Internal;
using PicPaySimplificado.Infrasctructure.DbContexts;
using PicPaySimplificado.Infrasctructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Services.Services.User
{
    public class UserService
    {
        private PicPayDbContext _dbContext { get; set; }
        public UserService(PicPayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CratedMockUsers()
        {
            

            var payee = new Infrasctructure.Entities.User();
            var payeeWallet = new Wallet
            {
                Balance = 200,
                User = payee,
                UserId = payee.Id
            };

            payee.Email = "payee@email.com";
            payee.IsSeller = true;
            payee.Name = "payee";
            payee.Wallet = payeeWallet;

            var payer = new Infrasctructure.Entities.User();
            var payerWallet = new Wallet
            {
                Balance = 200,
                User = payer,
                UserId = payer.Id
            };

            payer.Email = "payer@email.com";
            payer.IsSeller = false;
            payer.Name = "payer";
            payer.Wallet = payerWallet;

            _dbContext.Users.Add(payer);
            _dbContext.Users.Add(payee);
            _dbContext.Wallets.Add(payerWallet);
            _dbContext.Wallets.Add(payeeWallet);

            _dbContext.SaveChanges();

        }

        public async Task<IEnumerable<Infrasctructure.Entities.User>> GetAll()
        {
            return _dbContext.Users;

        }
    }
}
