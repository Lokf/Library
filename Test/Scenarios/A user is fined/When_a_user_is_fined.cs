namespace Lokf.Library.Test.Scenarios.A_user_is_fined
{
    using CommandHandlers;
    using Contracts.Commands;
    using Infrastructure;
    using System;

    public abstract class When_a_user_is_fined : CommandTest<FineUserCommand>
    {
        protected static readonly Guid _userId = Guid.NewGuid();

        protected override ICommandHandler<FineUserCommand> OnHandler()
        {
            return new FineUserCommandHandler(Users);
        }

        protected override FineUserCommand When()
        {
            return new FineUserCommand(_userId, Guid.Empty, 100);
        }
    }
}
