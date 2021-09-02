using System;
using System.Runtime.Serialization;

namespace ChatA.Application.Common.Exceptions
{
    public class IndividualMessageRoomAlreadyExistsException : Exception
    {
        public IndividualMessageRoomAlreadyExistsException()
        {
        }

        public IndividualMessageRoomAlreadyExistsException(string message) : base(message)
        {
        }

        public IndividualMessageRoomAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IndividualMessageRoomAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
