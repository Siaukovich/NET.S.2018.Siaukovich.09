namespace CustomExceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Bank account not found exception.
    /// </summary>
    public class BankAccountNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountNotFoundException"/> class.
        /// </summary>
        public BankAccountNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// Message that describes the error.
        /// </param>
        public BankAccountNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// Message that describes the error.
        /// </param>
        /// <param name="inner">
        /// The exception that is the cause of the current 
        /// exception or a null reference if ni inner exception is specified.
        /// </param>
        public BankAccountNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountNotFoundException"/> class.
        /// </summary>
        /// <param name="info">
        /// Serialization info.
        /// </param>
        /// <param name="context">
        /// Streaming context.
        /// </param>
        protected BankAccountNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
