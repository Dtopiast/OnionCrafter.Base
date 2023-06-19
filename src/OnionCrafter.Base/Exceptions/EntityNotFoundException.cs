namespace OnionCrafter.Base.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an entity is not found.
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Creates a new instance of EntityNotFoundException.
        /// </summary>
        /// <returns>
        /// A new instance of EntityNotFoundException.
        /// </returns>
        public EntityNotFoundException()
        { }

        /// <summary>
        /// Creates an instance of EntityNotFoundException with the specified message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <returns>A new instance of EntityNotFoundException.</returns>
        /// <summary>
        /// Creates an instance of EntityNotFoundException with the specified message.
        /// </summary>
        /// <returns>A new instance of EntityNotFoundException.</returns>
        public EntityNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the EntityNotFoundException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        /// <returns>A new instance of the EntityNotFoundException class.</returns>
        public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Constructor for EntityNotFoundException that takes in a SerializationInfo and StreamingContext.
        /// </summary>
        protected EntityNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}