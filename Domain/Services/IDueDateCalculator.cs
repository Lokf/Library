namespace Lokf.Library.Services
{
    using System;

    /// <summary>
    /// Defines the method for calculating a due date.
    /// </summary>
    public interface IDueDateCalculator
    {
        /// <summary>
        /// Calculates the the due date.
        /// </summary>
        /// <param name="lendDate">The lend date.</param>
        /// <returns>The due date.</returns>
        DateTime CalculateDueDate(DateTime lendDate);
    }
}
