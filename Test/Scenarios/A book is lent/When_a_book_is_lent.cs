namespace Lokf.Library.Test.Scenarios.A_book_is_lent
{
    using CommandHandlers;
    using Contracts.Commands;
    using Infrastructure;
    using Services;
    using System;

    public abstract class When_a_book_is_lent : CommandTest<LendBookCommand>
    {
        protected static readonly Guid _userId = Guid.NewGuid();

        protected override ICommandHandler<LendBookCommand> OnHandler()
        {
            return new LendBookCommandHandler(Users, Lendings, new DueDateCalculator());
        }

        protected override LendBookCommand When()
        {
            return new LendBookCommand(Guid.Empty, _userId, Guid.Empty, new DateTime(2014, 7, 10));
        }
    }
}
