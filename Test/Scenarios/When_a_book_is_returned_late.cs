namespace Lokf.Library.Test.Scenarios
{
    using Contracts.Commands;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lendings;
    using CommandHandlers;
    using Contracts.Events;

    [TestFixture]
    public class When_a_book_is_returned_late : CommandTest<ReturnBookCommand>
    {
        private static readonly Guid _lendingId = Guid.NewGuid();

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new BookLentEvent(_lendingId, Guid.Empty, Guid.Empty, new DateTime(2014, 7, 10), new DateTime(2014, 8, 9));
        }

        protected override ICommandHandler<ReturnBookCommand> OnHandler()
        {
            var repository = new DomainRepository<Lending>(UnitOfWork);

            return new ReturnBookCommandHandler(repository);
        }

        protected override ReturnBookCommand When()
        {
            return new ReturnBookCommand(_lendingId, new DateTime(2014, 8, 11));
        }

        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new BookReturnedLateEvent(_lendingId, new DateTime(2014, 8, 11), new DateTime(2014, 8, 9));
        }
    }
}
