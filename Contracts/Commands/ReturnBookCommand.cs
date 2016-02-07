namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;

    public class ReturnBookCommand : Command
    {
        public ReturnBookCommand(Guid lendingId, DateTime returnDate)
            : base(lendingId)
        {
            ReturnDate = returnDate;
        }

        public DateTime ReturnDate { get; }
    }
}
