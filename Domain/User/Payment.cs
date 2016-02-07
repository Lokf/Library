using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
