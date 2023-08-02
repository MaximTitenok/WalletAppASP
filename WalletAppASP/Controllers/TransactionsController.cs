
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WalletAppASP.Data;
using WalletAppASP.Models;
using WalletAppASP.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WalletAppASP.Services.Interfaces;

namespace WalletAppASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ILogger<TransactionsController> _logger;

        private readonly ITransactions _transactions;

        public TransactionsController(ILogger<TransactionsController> logger,ITransactions transactions)
        {
            _logger = logger;
            _transactions = transactions;
        }
        // GET api/transactions/userId
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<TransactionModel>> GetTransactions(int userId)
        {
            return _transactions.GetTransactions(userId);
        }
        [HttpGet("{userId}/{transactionId}")]
        public ActionResult<TransactionModel> GetTransactionByUser(int userId, int transactionId)
        {
            return _transactions.GetTransactionByUser(userId, transactionId);
        }
    }
}
