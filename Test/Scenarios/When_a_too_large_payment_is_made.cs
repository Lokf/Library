namespace Lokf.Library.Test.Scenarios
{
    using System;
    using System.Collections.Generic;
    using Infrastructure;
    using Contracts.Commands;
    using CommandHandlers;
    using Users;
    using Contracts.Events;

    public class When_a_too_large_payment_is_made : CommandTest<MakePaymentCommand>
    {
        private static readonly Guid _userId = Guid.NewGuid();

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "199006251277");
            yield return new UserFinedEvent(_userId, Guid.Empty, 50);
        }

        protected override ICommandHandler<MakePaymentCommand> OnHandler()
        {
            var repository = new DomainRepository<User>(UnitOfWork);

            return new MakePaymentCommandHandler(repository);
        }

        protected override MakePaymentCommand When()
        {
            return new MakePaymentCommand(_userId, 100, new DateTime(2014, 7, 10));
        }

        protected override Exception ExpectedException()
        {
            return new TooLargePaymentException();
        }
    }
}