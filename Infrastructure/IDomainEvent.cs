namespace Lokf.Library.Infrastructure
{
    using System;

    /// <summary>
    /// A domain event is raised by an aggregate and represent something that has happened.
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// Gets the ID of the aggregate that raised the event.
        /// </summary>
        Guid AggregateId { get; }

        /// <summary>
        /// Gets the ID of the event.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets or sets the version of the aggregate after the event was raised.
        /// </summary>
        int Version { get; set; }
    }
}
