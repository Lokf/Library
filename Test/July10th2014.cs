namespace Lokf.Library.Test
{
    using Utils;
    using System;

    public class July10th2014 : IDateProvider
    {
        public DateTime Today()
        {
            return new DateTime(2014, 7, 10);
        }
    }
}
