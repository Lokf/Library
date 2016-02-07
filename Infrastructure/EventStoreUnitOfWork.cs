using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lokf.Library.Infrastructure
{
    public class EventStoreUnitOfWork : IEventStoreUnitOfWork
    {
        private readonly IEventStore _eventStore;

        private readonly List<AggregateRoot> _dirtyAggregates = new List<AggregateRoot>();

        public EventStoreUnitOfWork(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Add<TAggregate>(TAggregate aggregate)
            where TAggregate : AggregateRoot
        {
            _dirtyAggregates.Add(aggregate);
        }

        public TAggregate GetById<TAggregate>(Guid aggregateId)
            where TAggregate : AggregateRoot
        {
            var param = Expression.Parameter(typeof(Guid), "aggregateId");
            var ctor = typeof(TAggregate).GetConstructor(new[] { typeof(Guid) });
            var lambda = Expression.Lambda<Func<Guid, TAggregate>>(
                Expression.New(ctor, param), param);
            var func = lambda.Compile();

            var events = _eventStore.GetDomainEventsByAggregateId(aggregateId);

            var aggregate = func(aggregateId);

            aggregate.LoadFromHistory(events);

            _dirtyAggregates.Add(aggregate);

            return aggregate;
        }

        public void Commit()
        {
            foreach (var aggregate in _dirtyAggregates)
            {
                _eventStore.SaveDomainEvents(aggregate.AggregateId, aggregate.UncommittedEvents, aggregate.Version);

                aggregate.ClearUncommittedEvents();
            }

            _dirtyAggregates.Clear();
        }

        public void Rollback()
        {
            foreach (var aggregate in _dirtyAggregates)
            {
                aggregate.ClearUncommittedEvents();
            }

            _dirtyAggregates.Clear();
        }
    }
}
