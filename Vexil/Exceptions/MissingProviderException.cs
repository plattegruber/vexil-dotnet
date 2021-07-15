using System;

namespace Vexil.Exceptions
{
    /// <summary>
    /// An exception thrown when no provider has been configured.
    /// </summary>
    public class MissingProviderException : Exception
    {
        /// <see cref="Exception()"></see>
        public MissingProviderException() : base() { }

        /// <see cref="Exception(string)"></see>
        public MissingProviderException(string message) : base(message) { }

        /// <see cref="Exception(string, Exception)"></see>
        public MissingProviderException(string message, Exception inner) : base(message, inner) { }
    }
}
