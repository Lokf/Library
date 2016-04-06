namespace Lokf.Library.Utils
{
    using System;

    /// <summary>
    /// Provides the method for getting todays date.
    /// </summary>
    public interface IDateProvider
    {
        /// <summary>
        /// Gets todays date.
        /// </summary>
        /// <returns>Todays date.</returns>
        DateTime Today();
    }
}
