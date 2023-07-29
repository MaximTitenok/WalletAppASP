namespace WalletAppASP
{
    public static class CalculationPoints
    {
        public static int CalculatePoints(DateTime currentDate)
        {
            TimeSpan duration = currentDate - GetSeasonStartDate(currentDate);
            int daysSinceStart = duration.Days+1;

            int[] pointsArray = new int[daysSinceStart + 1];

            for (int day = 1; day <= daysSinceStart; day++)
            {
                if (day == 1)
                {
                    pointsArray[day] = 2;
                }
                else if (day == 2)
                {
                    pointsArray[day] = 3;
                }
                else
                {
                    int previousDayPoints = (int)((int)pointsArray[day - 1] * 0.6);
                    int beforePreviousDayPoints = (int)pointsArray[day - 2];
                    pointsArray[day] = previousDayPoints + beforePreviousDayPoints;
                }
            }
            return pointsArray.Sum();
        }

        private static DateTime GetSeasonStartDate(DateTime currentDate)
        {
            int year = currentDate.Year;

            switch (currentDate.Month)
            {
                case 1:
                case 2:
                    {
                        return new DateTime(year - 1, 12, 1);
                    }
                case 3:
                case 4:
                case 5:
                    {
                        return new DateTime(year, 3, 1);
                    }
                case 6:
                case 7:
                case 8:
                    {
                        return new DateTime(year, 6, 1);
                    }
                case 9:
                case 10:
                case 11:
                    {
                        return new DateTime(year, 9, 1);
                    }
                case 12:
                    {
                        return new DateTime(year, 12, 1);
                    }

            }
            return currentDate;
        }

    }
}
