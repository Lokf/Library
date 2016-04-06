namespace Lokf.Library.Infrastructure
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An event sourced object uses events for persistence. The object can
    /// then be returned to its state by replaying the previous events.
    /// </summary>
    public interface IEventSourced
    {
        /// <summary>
        /// Gets the aggregate ID.
        /// </summary>
        Guid AggregateId { get; }

        /// <summary>
        /// Gets the uncommitted event.
        /// </summary>
        IEnumerable<IDomainEvent> UncommittedEvents { get; }

        /// <summary>
        /// Gets the version of the event sourced objects.
        /// </summary>
        int Version { get; }

        /// <summary>
        /// Clears the uncommitted events, performed when the uncommitted events have been committed.
        /// </summary>
        void ClearUncommittedEvents();

        /// <summary>
        /// Loads an event sourced object to its current state by replaying the historical events.
        /// </summary>
        /// <param name="history">The history of previous events.</param>
        void LoadFromHistory(IEnumerable<IDomainEvent> history);
    }
}
