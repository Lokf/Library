namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MakePaymentCommand : Command
    {
        public MakePaymentCommand(Guid userId, decimal amount, DateTime date)
            : base(userId)
        {
            Amount = amount;

            Date = date;
        }

        public decimal Amount { get; }

        public DateTime Date { get; }

    }
}
