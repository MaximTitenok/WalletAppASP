namespace WalletAppASP.Services.Interfaces
{
    public interface ICalculationPoints
    {
        public int CalculatePoints(DateTime currentDate);
        public DateTime GetSeasonStartDate(DateTime currentDate);
    }
}
