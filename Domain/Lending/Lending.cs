namespace Lokf.Library.Lendings
{
    using Infrastructure;
    using Contracts.Events;
    using System;
    using Services;

    public sealed class Lending : AggregateRoot
    {
        private Status _status = Status.None;

        private DateTime _dueDate;

        public Lending(Guid lendingId) 
            : base(lendingId)
        {
            RegisterEventHandlers();
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

        private void RegisterEventHandlers()
        {
            Handles<BookLentEvent>(OnBookLent);
            Handles<BookReturnedInTimeEvent>(OnBookReturnedInTime);
            Handles<BookReturnedLateEvent>(OnBookReturnedLate);
        }

        private void OnBookReturnedInTime(BookReturnedInTimeEvent @event)
        {
            _status = Status.Returned;
        }

        private void OnBookReturnedLate(BookReturnedLateEvent @event)
        {
            _status = Status.Returned;
        }

        private void OnBookLent(BookLentEvent @event)
        {
            _status = Status.Lent;

            _dueDate = @event.DueDate;
        }

        private enum Status
        {
            None = 0,
            Lent = 1,
            Returned = 2,
            Annulled = 3
        }
    }
}
