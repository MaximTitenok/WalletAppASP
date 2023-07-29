using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletAppASP.Controllers;
using WalletAppASP.Data;
using WalletAppASP.Models;

namespace WalletAppASP.Tests.ControllersTests
{
    public class TransactionsControllerTests
    {
        [Fact]
        public void TransactionsController_GetTransactions_ReturnsListOfTransactions_ForValidUserId()
        {
            // Arrange
            int userId = 1;
            int transactionId = 1;
            var transactionData = new TransactionModel
            {
                Id = transactionId,
                User = new UserModel { Id = userId },
                Date = DateTime.Now
            };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var dbContext = new ApplicationDBContext(dbContextOptions);
            dbContext.Transactions.Add(transactionData);

            var controller = new TransactionsController(A.Fake<ILogger<TransactionsController>>(), dbContext);

            // Act
            var result = controller.GetTransactions(userId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ActionResult<IEnumerable<TransactionModel>>));
        }
        [Fact]
        public void TransactionsController_GetTransactionByUser_Transaction_ForValidUserId()
        {
            // Arrange
            int userId = 1;
            int transactionId = 1;
            var transactionData = new TransactionModel
            {
                Id = transactionId,
                User = new UserModel { Id = userId },
                Date = DateTime.Now
            };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var dbContext = new ApplicationDBContext(dbContextOptions);
            dbContext.Transactions.Add(transactionData);

            var controller = new TransactionsController(A.Fake<ILogger<TransactionsController>>(), dbContext);

            // Act
            var result = controller.GetTransactionByUser(userId, transactionId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ActionResult<TransactionModel>));
        }
    }
}
