namespace OnionCrafter.Base.Exceptions
{
    /// <summary>
    /// Exception thrown when service arguments are not supported.
    /// </summary>
    [Serializable]
    public class NotSupportedServiceArgumentsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotSupportedServiceArgumentsException"/> class.
        /// </summary>
        public NotSupportedServiceArgumentsException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSupportedServiceArgumentsException"/> class with a specified error message.
        /// </summary>
        public NotSupportedServiceArgumentsException(string message) : base(message)
        {
        }

        public NotSupportedServiceArgumentsException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NotSupportedServiceArgumentsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}