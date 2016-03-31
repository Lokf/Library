namespace Lokf.Library.Test
{
    using System;
    using Utils;

    public class July10th2014 : IDateProvider
    {
        public DateTime Today()
        {
            return new DateTime(2014, 7, 10);
        }
    }
}
