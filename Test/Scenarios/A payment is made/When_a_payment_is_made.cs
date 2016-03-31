namespace Lokf.Library.Test.Scenarios.A_payment_is_made
{
    using CommandHandlers;
    using Contracts.Commands;
    using Infrastructure;
    using System;

    public abstract class When_a_payment_is_made : CommandTest<MakePaymentCommand>
    {
        protected static readonly Guid _userId = Guid.NewGuid();

        protected override ICommandHandler<MakePaymentCommand> OnHandler()
        {
            return new MakePaymentCommandHandler(Users);
        }

        protected override MakePaymentCommand When()
        {
            return new MakePaymentCommand(_userId, 100, new DateTime(2014, 7, 10));
        }
    }
}
