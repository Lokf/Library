namespace Lokf.Library.Infrastructure
{
    using System;

    /// <summary>
    /// Base class for all domain events.
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEvent"/> class. Sets the aggregate ID.
        /// An ID for for the event is also generated.
        /// </summary>
        /// <param name="aggregateId">The aggregate ID.</param>
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;

            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the ID of the aggregate root.
        /// </summary>
        public Guid AggregateId { get; }

        /// <summary>
        /// Gets the ID of the event itself.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets or sets the version of the aggregate root after the event was raised.
        /// </summary>
        int IDomainEvent.Version { get; set; }  
    }
}