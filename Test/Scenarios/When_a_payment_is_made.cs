

namespace Lokf.Library.Test.Scenarios
{
    using Contracts.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Infrastructure;
    using Users;
    using CommandHandlers;
    using Contracts.Events;

    public class When_a_payment_is_made : CommandTest<MakePaymentCommand>
    {
        private static readonly Guid _userId = Guid.NewGuid();

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "199006251277");
            yield return new UserFinedEvent(_userId, Guid.Empty, 100);
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

        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new PaymentMadeEvent(_userId, 100, new DateTime(2014, 7, 10));
        }
    }
}
