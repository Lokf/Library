using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokf.Library.Infrastructure
{
    public abstract class Entity
    {
        private readonly IRootEntity _aggregateRoot;

        private readonly Guid _entityId;

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class. 
        /// </summary>
        /// <param name="aggregateRoot">The aggregate Root.</param>
        /// <param name="entityId">The entity ID.</param>
        public Entity(IRootEntity aggregateRoot, Guid entityId)
        {
            _aggregateRoot = aggregateRoot;

            _entityId = entityId;
        }

        /// <summary>
        /// Registers a handler for an event type.
        /// </summary>
        /// <typeparam name="TEvent">The event type.</typeparam>
        /// <param name="handler">The event handler.</param>
        protected void Handles<TEvent>(Action<TEvent> handler) where TEvent : IDomainEvent
        {
            _aggregateRoot.Handles(handler);
        }
    }
}
