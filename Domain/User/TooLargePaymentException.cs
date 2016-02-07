namespace Lokf.Library.Users
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TooLargePaymentException : Exception
    {
        public TooLargePaymentException()
        {

        }

        public TooLargePaymentException(string message)
            :base(message)
        {

        }

        public TooLargePaymentException(string message, Exception inner)
            : base(message, inner)
        {

        }

        protected TooLargePaymentException(SerializationInfo info, StreamingContext context)
            : base (info, context)
        {

        }
    }
}
