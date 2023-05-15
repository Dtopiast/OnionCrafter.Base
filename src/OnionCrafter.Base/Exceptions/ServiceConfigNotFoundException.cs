namespace OnionCrafter.Base.Exceptions
{
    /// <summary>
    /// Exception thrown when a service configuration is not found.
    /// </summary>
    [Serializable]
    public class ServiceConfigNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceConfigNotFoundException"/> class.
        /// </summary>
        public ServiceConfigNotFoundException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceConfigNotFoundException"/> class with a specified error message.
        /// </summary>
        public ServiceConfigNotFoundException(string message) : base(message)
        {
        }

        public ServiceConfigNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ServiceConfigNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}