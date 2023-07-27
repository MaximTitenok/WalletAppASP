﻿
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WalletAppASP.Data;
using WalletAppASP.Models;

namespace WalletAppASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly ILogger<TransactionsController> _logger;

        private readonly ApplicationDBContext _dbContext;

        public TransactionsController(ILogger<TransactionsController> logger,ApplicationDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        // GET api/transactions/userId
        [HttpGet("userId")]
        public ActionResult<IEnumerable<TransactionModel>> GetTransactions(int userId)
        {
            // Отримати транзакції для певного користувача (userId)
            var transactions = _dbContext.Transactions
                .Where(t => t.User.Id == userId)
                .OrderByDescending(t => t.Date)
                .Take(10)
                .Select(t => new TransactionModel
                {
                    Id = t.Id,
                    Sum = t.Sum,
                    Name = t.Name,
                    Description = t.Description,
                    User = t.User,
                    Types = t.Types,
                })
                .ToList();
            return transactions;
        }
        [HttpGet("userId/{transactionId}")]
        public ActionResult<IEnumerable<TransactionModel>> GetTransaction(int userId, int transactionId)
        {
            // Отримати транзакції для певного користувача (userId) по id транзакции (transactionId)
            var transactions = _dbContext.Transactions
                .Where(t => t.User.Id == userId && t.Id == transactionId)
                .OrderByDescending(t => t.Date)
                .Take(10)
                .ToList();
            return transactions;
        }
    }
}