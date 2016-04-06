namespace Lokf.Library.Users
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception for when a payment is too large.
    /// </summary>
    [Serializable]
    public class TooLargePaymentException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TooLargePaymentException"/> class.
        /// </summary>
        public TooLargePaymentException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TooLargePaymentException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public TooLargePaymentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TooLargePaymentException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public TooLargePaymentException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TooLargePaymentException"/> class.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected TooLargePaymentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
