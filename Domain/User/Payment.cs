using System;

namespace Lokf.Library.Users
{
    public class Payment
    {
        public Payment(decimal amount, DateTime date)
        {
            Amount = amount;

            Date = date;
        }

        public decimal Amount { get; }

        public DateTime Date { get; }
    }
}
