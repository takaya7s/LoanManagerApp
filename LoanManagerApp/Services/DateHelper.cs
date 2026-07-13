using System;

namespace LoanManagerApp.Services
{
    internal static class DateHelper
    {
        public static DateTime CreateDueDate(DateTime targetMonth, int day)
        {
            int actualDay = Math.Min(day, DateTime.DaysInMonth(targetMonth.Year, targetMonth.Month));
            return new DateTime(targetMonth.Year, targetMonth.Month, actualDay);
        }

        public static DateTime MoveToPreviousWeekday(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                return date.AddDays(-1);
            }

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return date.AddDays(-2);
            }

            return date;
        }

        public static DateTime FirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
    }
}
