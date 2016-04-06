namespace Lokf.Library.Lendings
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exception for when a book have already been returned.
    /// </summary>
    [Serializable]
    public class BookAlreadyReturnedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookAlreadyReturnedException"/> class.
        /// </summary>
        public BookAlreadyReturnedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookAlreadyReturnedException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public BookAlreadyReturnedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookAlreadyReturnedException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public BookAlreadyReturnedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookAlreadyReturnedException"/> class.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        /// <param name="context">The streaming context.</param>
        protected BookAlreadyReturnedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
