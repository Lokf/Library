namespace Lokf.Library.Infrastructure
{
    using System;

    /// <summary>
    /// Provides functionality for hooking up event handling within entities.
    /// </summary>
    public interface IRootEntity
    {
        /// <summary>
        /// Specifies what handling that should occur for a specific type of event.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="handler">The handler for the event type.</param>
        void Handles<TEvent>(Action<TEvent> handler)
            where TEvent : IDomainEvent;
    }
}
