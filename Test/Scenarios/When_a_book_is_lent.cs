namespace Lokf.Library.Test.Scenarios
{
    using Contracts.Commands;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using CommandHandlers;
    using Contracts.Events;
    using Lendings;
    using Services;
    using Users;

    [TestFixture]
    public class When_a_book_is_lent : CommandTest<LendBookCommand>
    {
        private static readonly Guid _userId = Guid.NewGuid();

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "900625-1277");
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

        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new BookLentEvent(Guid.Empty, _userId, Guid.Empty, new DateTime(2014, 7, 10), new DateTime(2014, 8, 9));
        }
    }
}
