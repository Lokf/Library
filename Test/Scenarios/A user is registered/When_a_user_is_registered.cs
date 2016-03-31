namespace Lokf.Library.Test.Scenarios.A_user_is_registered
{
    using CommandHandlers;
    using Contracts.Commands;
    using Infrastructure;
    using System;

    public abstract class When_a_user_is_registered : CommandTest<RegisterUserCommand>
    {
        protected override ICommandHandler<RegisterUserCommand> OnHandler()
        {
            return new RegisterUserCommandHandler(Users);
        }

        protected override RegisterUserCommand When()
        {
            return new RegisterUserCommand(Guid.Empty, "900625-1277");
        }
    }
}
