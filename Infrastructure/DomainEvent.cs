namespace Lokf.Library.Infrastructure
{ 
    using System;

    /// <summary>
    /// Base class for all domain events.
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        /// <summary>
        /// The ID of the aggregate root.
        /// </summary>
        public Guid AggregateId { get; }

        /// <summary>
        /// The ID of the event itself.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The version of the aggregate root when the event was raised.
        /// </summary>
        int IDomainEvent.Version { get; }
    }
}
