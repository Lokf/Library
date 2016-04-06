namespace Lokf.Library.Lendings
{
    using Contracts.Events;
    using Infrastructure;
    using Services;
    using System;

    /// <summary>
    /// Represents a lending. It is the aggregate root of the lending aggregate.
    /// </summary>
    public sealed class Lending : AggregateRoot
    {
        private DateTime _dueDate;
        private Status _status = Status.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lending"/> class.
        /// </summary>
        /// <param name="lendingId">The lending ID.</param>
        public Lending(Guid lendingId)
            : base(lendingId)
        {
            RegisterEventHandlers();
        }

        private enum Status
        {
            None = 0,
            Lent = 1,
            Returned = 2,
            Annulled = 3
        }

        /// <summary>
        /// A book is lent.
        /// </summary>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="userId">The user ID.</param>
        /// <param name="bookId">The book ID.</param>
        /// <param name="lendDate">The date the book was lent.</param>
        /// <param name="dueDateCalculator">The due date calculator.</param>
        /// <returns>The lending.</returns>
        public static Lending LendBook(Guid lendingId, Guid userId, Guid bookId, DateTime lendDate, IDueDateCalculator dueDateCalculator)
        {
            var lending = new Lending(lendingId);

            var dueDate = dueDateCalculator.CalculateDueDate(lendDate);

            lending.RaiseEvent(new BookLentEvent(lendingId, userId, bookId, lendDate, dueDate));

            return lending;
        }

        /// <summary>
        /// The book is returned.
        /// </summary>
        /// <param name="returnDate">The date the book is returned.</param>
        public void ReturnBook(DateTime returnDate)
        {
            if (_status == Status.Returned)
            {
                throw new BookAlreadyReturnedException();
            }

            if (returnDate > _dueDate)
            {
                RaiseEvent(new BookReturnedLateEvent(AggregateId, returnDate, _dueDate));
            }
            else
            {
                RaiseEvent(new BookReturnedInTimeEvent(AggregateId, returnDate));
            }
        }

        private void OnBookLent(BookLentEvent @event)
        {
            _status = Status.Lent;

            _dueDate = @event.DueDate;
        }

        private void OnBookReturnedInTime(BookReturnedInTimeEvent @event)
        {
            _status = Status.Returned;
        }

        private void OnBookReturnedLate(BookReturnedLateEvent @event)
        {
            _status = Status.Returned;
        }

        private void RegisterEventHandlers()
        {
            Handles<BookLentEvent>(OnBookLent);
            Handles<BookReturnedInTimeEvent>(OnBookReturnedInTime);
            Handles<BookReturnedLateEvent>(OnBookReturnedLate);
        }
    }
}
