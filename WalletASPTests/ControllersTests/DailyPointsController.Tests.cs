using Castle.Core.Logging;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WalletAppASP;
using WalletAppASP.Controllers;

namespace WalletAppASP.Tests.ControllerTests
{
    public class DailyPointsControllerTests
    {
        [Fact]
        public void DailyPointsController_GetDailyPoints_Should_Return_Integer()
        {
            // Arrange
            var logger = A.Fake<ILogger<DailyPointsController>>();
            var controller = new DailyPointsController(logger);

            // Act
            var result = controller.GetDailyPoints();

            // Assert
            result.Should().NotBe(null);
            result.Should().BeOfType(typeof(ActionResult<int>));

        }
    }
}