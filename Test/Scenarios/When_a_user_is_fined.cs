namespace Lokf.Library.Test.Scenarios
{
    using Contracts.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Infrastructure;
    using Contracts.Events;
    using NUnit.Framework;
    using Users;
    using CommandHandlers;

    [TestFixture]
    public class When_a_user_is_fined : CommandTest<FineUserCommand>
    {
        private static readonly Guid _userId = Guid.NewGuid();

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "900625-1277");
        }

        protected override FineUserCommand When()
        {
            return new FineUserCommand(_userId, Guid.Empty, 100);
        }

        protected override ICommandHandler<FineUserCommand> OnHandler()
        {
            var repository = new DomainRepository<User>(UnitOfWork);

            return new FineUserCommandHandler(repository);
        }

        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new UserFinedEvent(_userId, Guid.Empty, 100);
        }
    }
}
