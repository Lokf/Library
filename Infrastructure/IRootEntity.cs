namespace Lokf.Library.Infrastructure
{
    using System;

    public interface IRootEntity
    {
        void Handles<TEvent>(Action<TEvent> handler)
            where TEvent : IDomainEvent;
    }
}
