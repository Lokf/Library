namespace Lokf.Library.Test.Scenarios.A_book_is_returned
{
    using CommandHandlers;
    using Contracts.Commands;
    using Infrastructure;
    using System;

    public abstract class When_a_book_is_returned : CommandTest<ReturnBookCommand>
    {
        protected static readonly Guid _lendingId = Guid.NewGuid();

        protected override ICommandHandler<ReturnBookCommand> OnHandler()
        {
            return new ReturnBookCommandHandler(Lendings);
        }

        protected override ReturnBookCommand When()
        {
            return new ReturnBookCommand(_lendingId, new DateTime(2014, 7, 11));
        }
    }
}
