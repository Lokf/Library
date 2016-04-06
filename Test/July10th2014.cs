namespace Lokf.Library.Test
{
    using System;
    using Utils;

    /// <summary>
    /// Represents todays date by July the 10th 2014-.
    /// </summary>
    public class July10th2014 : IDateProvider
    {
        /// <summary>
        /// Gets July the 10th 2014 as todays date.
        /// </summary>
        /// <returns>July the 10th 2014.</returns>
        public DateTime Today()
        {
            return new DateTime(2014, 7, 10);
        }
    }
}
