namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;

    public class LendBookCommand : Command
    {
        public LendBookCommand(Guid lendingId, Guid userId, Guid bookId, DateTime lendDate)
            : base(lendingId)
        {
            UserId = userId;

            BookId = bookId;

            LendDate = lendDate;
        }

        public Guid BookId { get; }

        public DateTime LendDate { get; }

        public Guid UserId { get; }
    }
}
