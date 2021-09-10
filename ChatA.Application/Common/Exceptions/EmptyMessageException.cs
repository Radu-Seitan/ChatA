using System;
using System.Runtime.Serialization;

namespace ChatA.Application.Common.Exceptions
{
    public class EmptyMessageException : Exception
    {
        public EmptyMessageException()
        {
        }

        public EmptyMessageException(string message) : base(message)
        {
        }

        public EmptyMessageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyMessageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
