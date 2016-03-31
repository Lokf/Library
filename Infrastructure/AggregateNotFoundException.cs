namespace Lokf.Library.Infrastructure
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException()
        {
        }

        public AggregateNotFoundException(string message)
            : base(message)
        {
        }

        public AggregateNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected AggregateNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
