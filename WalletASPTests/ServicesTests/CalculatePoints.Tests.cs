using WalletAppASP.Services;

namespace WalletAppASP.Tests.ServicesTests
{
    public class CalculationPointsTests
    {
        CalculationPoints _calculationPoints;

        public CalculationPointsTests() 
        {
            _calculationPoints = new CalculationPoints();
        }

        [Theory]
        [InlineData("2023-07-15", 2485721)]
        [InlineData("2023-12-01", 2)]
        public void CalculationPoints_CalculatePoints_Should_Return_Correct_Total_Points(
            string currentDateStr, int expectedTotalPoints)
        {
            // Arrange
            DateTime currentDate = DateTime.Parse(currentDateStr);

            // Act
            var totalPoints = _calculationPoints.CalculatePoints(currentDate);

            // Assert
            totalPoints.Should().Be(expectedTotalPoints);
            totalPoints.Should().BePositive();
            totalPoints.Should().NotBe(null);
            totalPoints.Should().BeOfType(typeof(int));

        }
    }
}