namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;

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
