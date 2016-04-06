namespace Lokf.Library.Infrastructure
{
    /// <summary>
    /// A unit of work for an event store. Provides functionality for storing events in a transaction.
    /// </summary>
    public class EventStoreUnitOfWork : IUnitOfWork
    {
        private readonly IChangeTracker2 _changeTracker;
        private readonly IEventStore _eventStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreUnitOfWork"/> class.
        /// </summary>
        /// <param name="eventStore">The event store.</param>
        /// <param name="changeTracker">The change tracker.</param>
        public EventStoreUnitOfWork(IEventStore eventStore, IChangeTracker2 changeTracker)
        {
            _eventStore = eventStore;

            _changeTracker = changeTracker;
        }

        /// <summary>
        /// Commits the new events from the aggregates being tracked by the change tracker.
        /// </summary>
        public void Commit()
        {
            foreach (var aggregate in _changeTracker.DirtyAggregates)
            {
                _eventStore.SaveDomainEvents(aggregate.AggregateId, aggregate.UncommittedEvents, aggregate.Version);

                aggregate.ClearUncommittedEvents();
            }

            _changeTracker.ClearDirtyAggregates();
        }

        /// <summary>
        /// Rollbacks the new events from the aggregates being tracked by the change tracker.
        /// </summary>
        public void Rollback()
        {
            foreach (var aggregate in _changeTracker.DirtyAggregates)
            {
                aggregate.ClearUncommittedEvents();
            }

            _changeTracker.ClearDirtyAggregates();
        }
    }
}
