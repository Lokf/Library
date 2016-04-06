namespace Lokf.Library.Test
{
    using Domain.Utils;
    using Infrastructure;
    using Lendings;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Users;

    public abstract class CommandTest<TCommand>
        where TCommand : ICommand
    {
        protected Exception CaughtException;
        private InMemoryEventStore _eventStore;

        private LibraryUnitOfWork _unitOfWork;

        protected IDomainRepository<Lending> Lendings { get { return _unitOfWork.Lending; } }

        protected IDomainRepository<User> Users { get { return _unitOfWork.Users; } }

        [Test]
        public void SetUp()
        {
            _eventStore = new InMemoryEventStore(Given());

            _unitOfWork = new LibraryUnitOfWork(_eventStore, new ChangeTracker());

            CaughtException = null;

            var handler = WrapCommandHandlerInTransaction(OnHandler());

            try
            {
                handler.Handle(When());

                var expected = ExpectedEvents().ToList();

                var actual = _eventStore.PeekChanges();

                CompareEvents(expected, actual);
            }
            catch (Exception exception)
            {
                if (exception is AssertionException)
                {
                    throw;
                }

                CaughtException = exception;
            }
            finally
            {
                CompareExceptions(ExpectedException(), CaughtException);
            }
        }

        protected virtual IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield break;
        }

        protected virtual Exception ExpectedException()
        {
            return null;
        }

        protected virtual IEnumerable<IDomainEvent> Given()
        {
            yield break;
        }

        protected abstract ICommandHandler<TCommand> OnHandler();

        protected abstract TCommand When();

        private void CompareEvent(IDomainEvent expected, IDomainEvent actual)
        {
            var expectedType = expected.GetType();
            var actualType = actual.GetType();

            var message = $"Expected an event of type { expectedType } but the event was of type { actualType }.";
            Assert.AreEqual(expectedType, actualType, message);

            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

            foreach (var propertyInfo in expectedType.GetProperties(bindingFlags))
            {
                if (propertyInfo.Name == "Id")
                {
                    // The ID of the events does not have to be the same.
                    continue;
                }

                var expectedValue = expectedType.GetProperty(propertyInfo.Name).GetValue(expected);
                var actualValue = actualType.GetProperty(propertyInfo.Name).GetValue(actual);

                message = $"Expected { expectedType.Name }.{ propertyInfo.Name } to be { expectedValue } but was { actualValue }";
                Assert.AreEqual(expectedValue, actualValue, message);
            }
        }

        private void CompareEvents(IReadOnlyCollection<IDomainEvent> expected, IReadOnlyCollection<IDomainEvent> actual)
        {
            var message = $"Expected {expected.Count} {(expected.Count == 1 ? "event" : "events")} but {actual.Count} {(expected.Count == 1 ? "event" : "events")} occured.";

            Assert.AreEqual(expected.Count, actual.Count, message);

            var eventPairs = expected.Zip(actual, (e, a) => new { Expected = e, Actual = a });
            foreach (var eventPair in eventPairs)
            {
                CompareEvent(eventPair.Expected, eventPair.Actual);
            }
        }

        private void CompareExceptions(Exception expected, Exception actual)
        {
            string message;

            if (expected == null)
            {
                if (actual == null)
                {
                    return;
                }

                message = $"Did not expect any exception, but an exception of type {actual.GetType()} was thrown.";

                Assert.Fail(message);
            }

            if (actual == null)
            {
                message = $"An exception of type {expected.GetType()} was expected but no exception was thrown.";

                Assert.Fail(message);
            }

            message = $"Expected an exception of type {expected.GetType()} but an exception of type {actual.GetType()} was thrown";

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        private ICommandHandler<TCommand> WrapCommandHandlerInTransaction(ICommandHandler<TCommand> commandHandler)
        {
            return new TransactionalCommandHandler<TCommand>(commandHandler, _unitOfWork);
        }
    }
}
