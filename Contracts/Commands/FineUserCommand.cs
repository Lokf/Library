namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;

    public class FineUserCommand : Command
    {
        public FineUserCommand(Guid userId, Guid lendingId, decimal amount)
            : base(userId)
        {
            LendingId = lendingId;

            Amount = amount;
        }

        public decimal Amount { get; }

        public Guid LendingId { get; }
    }
}
