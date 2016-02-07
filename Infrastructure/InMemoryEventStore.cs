namespace Lokf.Library.Infrastructure
{
    using System;
    using System.Collections.Generic;

    public class InMemoryEventStore : IEventStore 
    {
        private readonly Dictionary<Guid, List<IDomainEvent>> _eventStore = new Dictionary<Guid, List<IDomainEvent>>();

        private readonly List<IDomainEvent> _changes = new List<IDomainEvent>();

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

        public IEnumerable<IDomainEvent> GetDomainEventsByAggregateId(Guid aggregateId)
        {
            List<IDomainEvent> aggregate;
            
            if (_eventStore.TryGetValue(aggregateId, out aggregate))
            {
                return aggregate;
            }

            throw new AggregateNotFoundException();
        }

        public void BeginTransaction()
        {

        }

        public void CommitTransaction()
        {

        }

        public void RollbackTransaction()
        {

        }

        public IReadOnlyCollection<IDomainEvent> PeekChanges()
        {
            return _changes;
        }
    }
}
