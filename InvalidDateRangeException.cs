using System;
using System.Runtime.Serialization;

namespace csharp
{
    [Serializable]
    internal class InvalidDateRangeException : Exception
    {
        public InvalidDateRangeException()
        {
        }

        public InvalidDateRangeException(string message) : base("The begin date must be earlier than the end date.")
        {
        }

        public InvalidDateRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDateRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}