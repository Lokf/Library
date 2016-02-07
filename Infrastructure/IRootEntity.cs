namespace Lokf.Library.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRootEntity
    {
        void Handles<TEvent>(Action<TEvent> handler)
            where TEvent : IDomainEvent;
    }
}
