namespace Lokf.Library.Infrastructure
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Repository for aggregates. Provides functionality for getting an aggregate by its ID or
    /// adding a new aggregate to the repository.
    /// </summary>
    /// <typeparam name="TAggregate">The type of aggregate.</typeparam>
    public class DomainRepository<TAggregate> : IDomainRepository<TAggregate>
        where TAggregate : AggregateRoot
    {
        private readonly IChangeTracker _changeTracker;
        private readonly IEventStore _eventStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainRepository{TAggregate}"/> class.
        /// </summary>
        /// <param name="eventStore">The event store to load aggregates from.</param>
        /// <param name="changeTracker">The change tracker.</param>
        public DomainRepository(IEventStore eventStore, IChangeTracker changeTracker)
        {
            _eventStore = eventStore;

            _changeTracker = changeTracker;
        }

        /// <summary>
        /// Adds a new aggregate to the repository.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        public void Add(TAggregate aggregate)
        {
            _changeTracker.MarkAsDirty(aggregate);
        }

        /// <summary>
        /// Gets the aggregate from the repository by its ID.
        /// </summary>
        /// <param name="aggregateId">The aggregate.</param>
        /// <returns>THe aggregate with the specified ID.</returns>
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
