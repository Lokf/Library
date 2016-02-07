namespace Lokf.Library.Services
{
    using System;

    public interface IDueDateCalculator
    {
        DateTime CalculateDueDate(DateTime lendDate);
    }
}
