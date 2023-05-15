namespace OnionCrafter.Base.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an entity cannot be cast to the specified type.
    /// </summary>
    [Serializable]
    public class InvalidEntityCastException : Exception
    {
        /// <summary>
        /// Represents an exception that is thrown when an invalid cast is attempted on an entity.
        /// </summary>
        public InvalidEntityCastException()
        { }

        /// <summary>
        /// Constructor for InvalidEntityCastException class with a message parameter.
        /// </summary>
        public InvalidEntityCastException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor for InvalidEntityCastException which takes a message and an inner exception as parameters.
        /// </summary>
        public InvalidEntityCastException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Constructor for InvalidEntityCastException class that takes in a SerializationInfo and StreamingContext.
        /// </summary>
        protected InvalidEntityCastException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}