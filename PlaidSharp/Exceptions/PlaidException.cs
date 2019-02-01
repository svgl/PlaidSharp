using PlaidSharp.Entities;
using System;

namespace PlaidSharp.Exceptions
{
    [Serializable]
    public class PlaidException : Exception
    {
        public virtual Error PlaidError { get; }

        public PlaidException() { }

        public PlaidException(Error error) : base(error.ToString())
        {
            PlaidError = error;
        }

        public PlaidException(string message) : base(message) { }

        public PlaidException(string message, Exception inner) : base(message, inner) { }

        protected PlaidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
