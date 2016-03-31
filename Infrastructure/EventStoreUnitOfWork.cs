namespace Lokf.Library.Infrastructure
{
    public class EventStoreUnitOfWork : IUnitOfWork
    {
        private readonly IChangeTracker2 _changeTracker;
        private readonly IEventStore _eventStore;

        public EventStoreUnitOfWork(IEventStore eventStore, IChangeTracker2 changeTracker)
        {
            _eventStore = eventStore;

            _changeTracker = changeTracker;
        }

        public void Commit()
        {
            foreach (var aggregate in _changeTracker.DirtyAggregates)
            {
                _eventStore.SaveDomainEvents(aggregate.AggregateId, aggregate.UncommittedEvents, aggregate.Version);

                aggregate.ClearUncommittedEvents();
            }

            _changeTracker.ClearDirtyAggregates();
        }

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
