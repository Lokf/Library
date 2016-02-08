namespace Lokf.Library.Infrastructure
{
    /// <summary>
    /// A event handler handles events.
    /// </summary>
    /// <typeparam name="TEvent">The type of event to handle.</typeparam>
    public interface IEventHandler<TEvent>
        where TEvent : IDomainEvent
    {
        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="event">The event to handle.</param>
        void Handle(TEvent @event);
    }
}
