namespace Lokf.Library.Services
{
    using System;
    using Utils;

    /// <summary>
    /// Calculator for calculating the latest return date.
    /// </summary>
    public class DueDateCalculator : IDueDateCalculator
    {
        private const int NumberOfDaysToLend = 30;

        /// <summary>
        /// Calculates the latest return date.
        /// </summary>
        /// <returns>The latest return date.</returns>
        public DateTime CalculateDueDate(DateTime lendDate)
        {
            return lendDate.AddDays(NumberOfDaysToLend);
        }
    }
}
