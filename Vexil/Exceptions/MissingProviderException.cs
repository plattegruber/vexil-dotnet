using System;

namespace Vexil.Exceptions
{
    public class MissingProviderException : Exception
    {
        public MissingProviderException() : base() { }

        public MissingProviderException(string message) : base(message) { }

        public MissingProviderException(string message, Exception inner) : base(message, inner) { }
    }
}
