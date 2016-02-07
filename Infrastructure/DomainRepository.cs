namespace Lokf.Library.Infrastructure
{
    using System;

    public class DomainRepository<TAggregate> : IDomainRepository<TAggregate>
        where TAggregate : AggregateRoot
    {
        private readonly IEventStoreUnitOfWork _unitOfWork;

        public DomainRepository(IEventStoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TAggregate aggregate)
        {
            _unitOfWork.Add(aggregate);
        }

        public TAggregate GetById(Guid aggregateId)
        {
            return _unitOfWork.GetById<TAggregate>(aggregateId);
        }
    }
}
