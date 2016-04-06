namespace Lokf.Library.Infrastructure
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An in memory event store. Provides functionality for storing and retrieving events. 
    /// </summary>
    public class InMemoryEventStore : IEventStore
    {
        private readonly List<IDomainEvent> _changes = new List<IDomainEvent>();
        private readonly Dictionary<Guid, List<IDomainEvent>> _eventStore = new Dictionary<Guid, List<IDomainEvent>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryEventStore"/> class.
        /// </summary>
        /// <param name="events">The events to store in the event store.</param>
        public InMemoryEventStore(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events)
            {
                List<IDomainEvent> aggregate;

                if (_eventStore.TryGetValue(@event.AggregateId, out aggregate))
                {
                    aggregate.Add(@event);
                }
                else
                {
                    aggregate = new List<IDomainEvent> { @event };

                    _eventStore.Add(@event.AggregateId, aggregate);
                }
            }
        }

        /// <summary>
        /// Begins a transaction.
        /// </summary>
        public void BeginTransaction()
        {
        }

        /// <summary>
        /// Commits a transaction
        /// </summary>
        public void CommitTransaction()
        {
        }

        /// <summary>
        /// Gets the events for the specified aggregate ID.
        /// </summary>
        /// <param name="aggregateId">The aggregate ID.</param>
        /// <returns>The events associated to that aggregate ID.</returns>
        public IEnumerable<IDomainEvent> GetDomainEventsByAggregateId(Guid aggregateId)
        {
            List<IDomainEvent> aggregate;

            if (_eventStore.TryGetValue(aggregateId, out aggregate))
            {
                return aggregate;
            }

            throw new AggregateNotFoundException();
        }

        /// <summary>
        /// Peeks at the changes.
        /// </summary>
        /// <returns>The changes.</returns>
        public IReadOnlyCollection<IDomainEvent> PeekChanges()
        {
            return _changes;
        }

        /// <summary>
        /// Rollbacks a transaction.
        /// </summary>
        public void RollbackTransaction()
        {
        }

        /// <summary>
        /// Saves the events. If the version of the stream of events for the specified aggregate ID differs from <paramref name="expectedVersion"/>
        /// an exception is thrown.
        /// </summary>
        /// <param name="aggregateId">The aggregate ID.</param>
        /// <param name="events">The events to store.</param>
        /// <param name="expectedVersion">The expected version.</param>
        public void SaveDomainEvents(Guid aggregateId, IEnumerable<IDomainEvent> events, int expectedVersion)
        {
            List<IDomainEvent> aggregate;

            if (_eventStore.TryGetValue(aggregateId, out aggregate))
            {
                if (expectedVersion != aggregate.Count)
                {
                    throw new Exception();
                }

                aggregate.AddRange(events);
            }
            else
            {
                if (expectedVersion != 0)
                {
                    throw new Exception();
                }

                aggregate = new List<IDomainEvent>(events);

                _eventStore.Add(aggregateId, aggregate);
            }

            _changes.AddRange(events);
        }
    }
}
