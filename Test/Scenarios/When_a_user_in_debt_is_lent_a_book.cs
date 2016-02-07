namespace Lokf.Library.Test.Scenarios
{
    using CommandHandlers;
    using Contracts.Commands;
    using Contracts.Events;
    using Infrastructure;
    using Lendings;
    using Services;
    using Users;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;


    [TestFixture]
    public class When_a_user_in_debt_is_lent_a_book : CommandTest<LendBookCommand>
    {
        private static readonly Guid _userId = Guid.NewGuid();

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "900625-1277");
            yield return new UserFinedEvent(_userId, Guid.Empty, 100);
        }

        protected override ICommandHandler<LendBookCommand> OnHandler()
        {
            var userRepository = new DomainRepository<User>(UnitOfWork);

            var lenidngRepository = new DomainRepository<Lending>(UnitOfWork);

            return new LendBookCommandHandler(userRepository, lenidngRepository, new DueDateCalculator());
        }

        protected override LendBookCommand When()
        {
            return new LendBookCommand(Guid.Empty, _userId, Guid.Empty, new DateTime(2014, 7, 10));
        }

        protected override Exception ExpectedException()
        {
            return new Exception();
        }
    }
}
