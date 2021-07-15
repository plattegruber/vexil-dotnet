using System;

namespace Vexil.Exceptions
{
    /// <summary>
    /// An exception thrown when the underlying configured provider throws any exception.
    /// </summary>
    public class ProviderException : Exception 
    {
        /// <see cref="Exception()"></see>
        public ProviderException() : base() { }

        /// <see cref="Exception(string)"></see>
        public ProviderException(string message) : base(message) { }

        /// <see cref="Exception(string, Exception)"></see>
        public ProviderException(string message, Exception inner) : base(message, inner) { }
    }
}
