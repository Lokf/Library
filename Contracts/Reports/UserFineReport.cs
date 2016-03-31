namespace Lokf.Library.Contracts.Reports
{
    using System;

    public class UserFineReport
    {
        public UserFineReport(Guid userId, Guid lendingId, decimal amount)
        {
            UserId = userId;

            LendingId = lendingId;

            Amount = amount;
        }

        public decimal Amount { get; }

        public Guid LendingId { get; }

        public Guid UserId { get; }
    }
}
