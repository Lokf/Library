using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokf.Library.Infrastructure
{
    public interface IEventStoreUnitOfWork : IUnitOfWork
    {
        TAggregate GetById<TAggregate>(Guid aggregateId)
            where TAggregate : AggregateRoot;

        void Add<TAggregate>(TAggregate aggregate)
            where TAggregate : AggregateRoot;        
    }
}
