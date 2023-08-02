using Microsoft.AspNetCore.Mvc;
using WalletAppASP.Models;

namespace WalletAppASP.Services.Interfaces
{
    public interface ITransactions
    {
        public ActionResult<IEnumerable<TransactionModel>> GetTransactions(int userId);
        public ActionResult<TransactionModel> GetTransactionByUser(int userId, int transactionId);
    }
}
