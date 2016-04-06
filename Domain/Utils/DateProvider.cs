namespace Lokf.Library.Utils
{
    using System;

    /// <summary>
    /// Provides todays date.
    /// </summary>
    public class DateProvider : IDateProvider
    {
        /// <summary>
        /// Gets todays date.
        /// </summary>
        /// <returns>Todays date.</returns>
        public DateTime Today()
        {
            return DateTime.Today;
        }
    }
}
