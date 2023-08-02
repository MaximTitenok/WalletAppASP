using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalletAppASP.Data;
using WalletAppASP.Models;
using WalletAppASP.Services.Interfaces;

namespace WalletAppASP.Services
{
    public class Transactions : ITransactions
    {
        private readonly ApplicationDBContext _dbContext;
        public Transactions(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult<IEnumerable<TransactionModel>> GetTransactions(int userId)
        {
            var transactions = _dbContext.Transactions
                .Where(t => t.User.Id == userId)
                .OrderByDescending(t => t.Date)
                .Take(10)
                .Include(t => t.User)
                .Include(t => t.AuthorizedUser)
                .ToList();
            return transactions ?? new List<TransactionModel>();
        }
        public ActionResult<TransactionModel> GetTransactionByUser(int userId, int transactionId)
        {
            var transactions = _dbContext.Transactions
                .Where(t => t.User.Id == userId && t.Id == transactionId)
                .Include(t => t.User)
                .SingleOrDefault();
            return transactions ?? new TransactionModel();
        }
    }
}
