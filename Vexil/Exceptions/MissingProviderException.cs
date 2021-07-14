using System;

namespace Vexil.Exceptions
{
    /// <summary>
    /// TODO: XML docs
    /// </summary>
    public class MissingProviderException : Exception
    {
        /// <summary>
        /// TODO: XML docs
        /// </summary>
        public MissingProviderException() : base() { }

        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <param name="message"></param>
        public MissingProviderException(string message) : base(message) { }

        /// <summary>
        /// TODO: XML docs
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public MissingProviderException(string message, Exception inner) : base(message, inner) { }
    }
}
