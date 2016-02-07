namespace Lokf.Library.Utils
{
    using System;

    public class DateProvider : IDateProvider
    {
        public DateTime Today()
        {
            return DateTime.Today;
        }
    }
}
