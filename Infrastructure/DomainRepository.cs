namespace Lokf.Library.Infrastructure
{
    using System;
    using System.Linq.Expressions;

    public class DomainRepository<TAggregate> : IDomainRepository<TAggregate>
        where TAggregate : AggregateRoot
    {
        private readonly IChangeTracker _changeTracker;
        private readonly IEventStore _eventStore;

        public DomainRepository(IEventStore eventStore, IChangeTracker changeTracker)
        {
            _eventStore = eventStore;

            _changeTracker = changeTracker;
        }

        public void Add(TAggregate aggregate)
        {
            _changeTracker.MarkAsDirty(aggregate);
        }

        public TAggregate GetById(Guid aggregateId)
        {
            var param = Expression.Parameter(typeof(Guid), "aggregateId");
            var ctor = typeof(TAggregate).GetConstructor(new[] { typeof(Guid) });
            var lambda = Expression.Lambda<Func<Guid, TAggregate>>(
                Expression.New(ctor, param), param);
            var func = lambda.Compile();

            var events = _eventStore.GetDomainEventsByAggregateId(aggregateId);

            var aggregate = func(aggregateId);

            aggregate.LoadFromHistory(events);

            _changeTracker.MarkAsDirty(aggregate);

            return aggregate;
        }
    }
}
