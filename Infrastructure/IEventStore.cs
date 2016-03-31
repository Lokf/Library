namespace Lokf.Library.Infrastructure
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An event store provides functionality for saving and loading events.
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// Begins a transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commits a transaction.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Gets the events stored by the aggregate ID.
        /// </summary>
        /// <param name="aggregateId">The aggregateId.</param>
        /// <returns>The events.</returns>
        IEnumerable<IDomainEvent> GetDomainEventsByAggregateId(Guid aggregateId);

        /// <summary>
        /// Rollbacks a transaction.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Saves the events and stores them keyed by the aggregate ID. If the version of the aggregate in the event store
        /// differs from the expected version an optmistic concurreny exception is thrown.
        /// </summary>
        /// <param name="aggregateId">The aggregate ID.</param>
        /// <param name="events">The events to store.</param>
        /// <param name="expectedVersion">The expected version of the aggregate.</param>
        void SaveDomainEvents(Guid aggregateId, IEnumerable<IDomainEvent> events, int expectedVersion);
    }
}
