using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Infrasctructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPaySimplificado.Infrasctructure.DbContexts
{
    public class PicPayDbContext : DbContext
    {

        public PicPayDbContext(DbContextOptions<PicPayDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);
                e.HasOne(u => u.Wallet)
                  .WithOne(w => w.User)
                  .HasForeignKey<Wallet>(w => w.UserId)
                  .IsRequired();

                e.HasMany(u => u.TransactionsAsPayer)
                    .WithOne(t => t.Payer)
                    .HasForeignKey(t => t.PayerId);

                e.HasMany(u => u.TransactionsAsPayee)
                     .WithOne(t => t.Payee)
                     .HasForeignKey(t => t.PayeeId);
            });

            modelBuilder.Entity<Wallet>(e =>
            {
                e.HasKey(w => w.Id);
                e.Property(w => w.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Transaction>(e =>
            {
                e.HasKey(t => t.Id);
                e.Property(t => t.Amount)
                    .IsRequired();

                // Relacionamento para o pagador
                e.HasOne(t => t.Payer)
                    .WithMany(u => u.TransactionsAsPayer)
                    .HasForeignKey(t => t.PayerId)
                    .IsRequired();

                // Relacionamento para o recebedor
                e.HasOne(t => t.Payee)
                    .WithMany(u => u.TransactionsAsPayee)
                    .HasForeignKey(t => t.PayeeId)
                    .IsRequired();
            });

        }

    }
}
