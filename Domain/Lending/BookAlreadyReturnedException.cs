namespace Lokf.Library.Lendings
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BookAlreadyReturnedException : Exception
    {
        public BookAlreadyReturnedException()
        {

        }

        public BookAlreadyReturnedException(string message)
            :base(message)
        {

        }

        public BookAlreadyReturnedException(string message, Exception inner)
            : base(message, inner)
        {

        }

        protected BookAlreadyReturnedException(SerializationInfo info, StreamingContext context)
            : base (info, context)
        {

        }
    }
}
