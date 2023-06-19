namespace OnionCrafter.Base.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid cast is attempted on a DTO object.
    /// </summary>
    [Serializable]
    public class InvalidDTOCastException : Exception
    {
        /// <summary>
        /// Exception thrown when an invalid DTO cast is attempted.
        /// </summary>
        /// <returns>
        /// An InvalidDTOCastException object.
        /// </returns>
        public InvalidDTOCastException()
        { }

        /// <summary>
        /// Constructor for InvalidDTOCastException class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>
        /// An instance of InvalidDTOCastException.
        /// </returns>
        public InvalidDTOCastException(string message) : base(message) { }

        /// <summary>
        /// Creates an instance of InvalidDTOCastException with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        /// <returns>An instance of InvalidDTOCastException.</returns>
        public InvalidDTOCastException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Represents an exception that is thrown when an invalid cast is attempted on a DTO object.
        /// </summary>
        protected InvalidDTOCastException(
               System.Runtime.Serialization.SerializationInfo info,
               System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}