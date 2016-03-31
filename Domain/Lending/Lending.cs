namespace Lokf.Library.Lendings
{
    using Contracts.Events;
    using Infrastructure;
    using Services;
    using System;

    public sealed class Lending : AggregateRoot
    {
        private DateTime _dueDate;
        private Status _status = Status.None;

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

        public static Lending LendBook(Guid lendingId, Guid userId, Guid bookId, DateTime lendDate, IDueDateCalculator dueDateCalculator)
        {
            var lending = new Lending(lendingId);

            var dueDate = dueDateCalculator.CalculateDueDate(lendDate);

            lending.RaiseEvent(new BookLentEvent(lendingId, userId, bookId, lendDate, dueDate));

            return lending;
        }

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
