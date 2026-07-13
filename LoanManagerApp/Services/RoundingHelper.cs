using System;

namespace LoanManagerApp.Services
{
    internal static class RoundingHelper
    {
        /// <summary>
        /// 1円未満を四捨五入します。
        /// 50銭未満は切り捨て、50銭以上は1円へ切り上げます。
        /// </summary>
        public static long RoundToYen(decimal value)
        {
            decimal rounded = decimal.Round(value, 0, MidpointRounding.AwayFromZero);
            return checked((long)rounded);
        }
    }
}
