﻿namespace Lokf.Library.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Base class for all aggregate roots. Provides functionality for event sourcing,
    /// i.e. rebuilding an aggregate from previous events and raising new events.
    /// </summary>
    public abstract class AggregateRoot : IEventSourced, IRootEntity
    {
        private readonly Dictionary<Type, Action<IDomainEvent>> _eventHandlers;

        private readonly List<IDomainEvent> _uncommittedEvents;

        private int _eventVersion;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate ID.</param>
        protected AggregateRoot(Guid aggregateId)
        {
            AggregateId = aggregateId;

            _eventHandlers = new Dictionary<Type, Action<IDomainEvent>>();

            _uncommittedEvents = new List<IDomainEvent>();
        }

        /// <summary>
        /// Gets the aggregate ID.
        /// </summary>
        public Guid AggregateId { get; }

        /// <summary>
        /// Gets the uncommitted events.
        /// </summary>
        public IEnumerable<IDomainEvent> UncommittedEvents
        {
            get
            {
                return _uncommittedEvents;
            }
        }

        /// <summary>
        /// Gets the current version of the aggregate.
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Clears the list of uncommitted events.
        /// </summary>
        public void ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        /// <summary>
        /// Registers a handler for an event type.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="handler">The event handler.</param>
        void IRootEntity.Handles<TEvent>(Action<TEvent> handler)
        {
            Handles(handler);
        }

        /// <summary>
        /// Brings the aggregate to its current state by loading the previous events.
        /// </summary>
        /// <param name="history">The previous events.</param>
        public void LoadFromHistory(IEnumerable<IDomainEvent> history)
        {
            foreach (var @event in history)
            {
                ApplyEvent(@event);
            }

            Version = history.Count();
        }

        /// <summary>
        /// Registers a handler for an event type.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="handler">The event handler.</param>
        protected void Handles<TEvent>(Action<TEvent> handler) where TEvent : IDomainEvent
        {
            _eventHandlers.Add(typeof(TEvent), @event => handler((TEvent)@event));
        }

        /// <summary>
        /// Raises an event. The event is applied to the aggregate using the appropriate event handler
        /// and added to the list of uncommitted events.
        /// </summary>
        /// <param name="event">The event to be raised.</param>
        protected void RaiseEvent(IDomainEvent @event)
        {
            ApplyEvent(@event);

            _uncommittedEvents.Add(@event);
        }

        private void ApplyEvent(IDomainEvent @event)
        {
            var eventType = @event.GetType();

            @event.Version = ++_eventVersion;

            Action<IDomainEvent> eventHandler;

            if (_eventHandlers.TryGetValue(eventType, out eventHandler))
            {
                eventHandler(@event);
            }
        }
    }
}
