namespace Lokf.Library.Infrastructure
{
    using System;

    /// <summary>
    /// Domain repository for event sourced objects.
    /// </summary>
    /// <typeparam name="TAggregate">The event sourced type.</typeparam>
    public interface IDomainRepository<TAggregate>
        where TAggregate : AggregateRoot
    {
        /// <summary>
        /// Adds a new aggregate to the repository for storage.
        /// </summary>
        /// <param name="aggregate">The aggregate to add to the repository.</param>
        void Add(TAggregate aggregate);

        /// <summary>
        /// Gets the aggregate by its ID.
        /// </summary>
        /// <param name="aggregateId">The aggregate ID.</param>
        /// <returns>The aggregate.</returns>
        TAggregate GetById(Guid aggregateId);
    }
}
