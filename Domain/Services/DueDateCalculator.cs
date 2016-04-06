namespace Lokf.Library.Services
{
    using System;

    /// <summary>
    /// Calculator for calculating the due date.
    /// </summary>
    public class DueDateCalculator : IDueDateCalculator
    {
        private const int NumberOfDaysToLend = 30;

        /// <summary>
        /// Calculates the latest return date.
        /// </summary>
        /// <param name="lendDate">The date the book was lent.</param>
        /// <returns>The latest return date.</returns>
        public DateTime CalculateDueDate(DateTime lendDate)
        {
            return lendDate.AddDays(NumberOfDaysToLend);
        }
    }
}
