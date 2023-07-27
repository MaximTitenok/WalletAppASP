namespace WalletAppASP
{
    public static class CalculationPoints
    {
        public static int CalculatePoints(DateTime currentDate)
        {

            TimeSpan duration = currentDate - GetSeasonStartDate();
            int daysSinceStart = duration.Days;

            int points = 0;
            for (int day = 1; day <= daysSinceStart; day++)
            {
                if (day == 1)
                {
                    points += 2;
                }
                else if (day == 2)
                {
                    points += 3;
                }
                else
                {
                    int previousDayPoints = (int)(points * 0.6);
                    points += previousDayPoints + 100;
                }
            }
            return points;
        }

        private static DateTime GetSeasonStartDate()
        {
            DateTime today = DateTime.Now;
            int year = today.Year;

            switch (today.Month)
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
            return today;
        }

    }
}
