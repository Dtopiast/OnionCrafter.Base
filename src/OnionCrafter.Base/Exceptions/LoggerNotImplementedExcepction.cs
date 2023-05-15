namespace OnionCrafter.Base.Exceptions
{
    /// <summary>
    /// Exception thrown when a logger implementation is not implemented or configured properly.
    /// </summary>
    [Serializable]
    public class LoggerNotImplementedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerNotImplementedException"/> class.
        /// </summary>
        /// <param name="logger">The name of the logger that is not implemented or configured properly.</param>
        public LoggerNotImplementedException(string logger) : base(logger + " , if your project does not require logging set the UseLogger option to false in your implementation. ")
        { }

        public LoggerNotImplementedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LoggerNotImplementedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}