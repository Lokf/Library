namespace Lokf.Library.Contracts.Events
{ 
    using Infrastructure;
    using System;

    public class BookLentEvent : DomainEvent
    {
        public BookLentEvent(Guid lendingId, Guid userId, Guid bookId, DateTime lendDate, DateTime dueDate)
            : base(lendingId)
        {
            UserId = userId;

            BookId = bookId;

            LendDate = lendDate;

            DueDate = dueDate;
        }

        public Guid UserId { get; }

        public Guid BookId { get; }

        public DateTime LendDate { get; }

        public DateTime DueDate { get; }
    }
}
