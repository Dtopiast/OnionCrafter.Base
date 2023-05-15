using Microsoft.Extensions.Logging;
using OnionCrafter.Base.Exceptions;

namespace OnionCrafter.Base.Utils
{
    /// <summary>
    /// Utility class for checking logger implementation.
    /// </summary>
    public static class LoggerUtils
    {
        /// <summary>
        /// Checks if the logger is implemented when it is expected to be enabled.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="isEnabled">Flag indicating if the logger is enabled.</param>
        /// <exception cref="LoggerNotImplementedException">Thrown when the logger is not implemented but it is expected to be enabled.</exception>
        public static void CheckLoggerImplementation(this ILogger? logger, bool isEnabled)
        {
            if (logger == null && isEnabled)
                throw new LoggerNotImplementedException(nameof(logger));
        }
    }
}