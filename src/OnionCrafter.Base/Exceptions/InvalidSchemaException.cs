using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Base.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid schema is encountered.
    /// </summary>
    [Serializable]
    public class InvalidSchemaException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the InvalidSchemaException class.
        /// </summary>
        /// <returns>A new instance of the InvalidSchemaException class.</returns>
        public InvalidSchemaException()
        { }

        /// <summary>
        /// Creates a new instance of the InvalidSchemaException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <returns>A new instance of the InvalidSchemaException class.</returns>
        public InvalidSchemaException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the InvalidSchemaException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        /// <returns>A new instance of the InvalidSchemaException class.</returns>
        public InvalidSchemaException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Constructs an InvalidSchemaException with the given SerializationInfo and StreamingContext.
        /// </summary>
        protected InvalidSchemaException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}