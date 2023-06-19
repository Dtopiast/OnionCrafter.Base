namespace OnionCrafter.Base.Utils
{
    /// <summary>
    /// Provides extension methods for handling exceptions.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the specified object is null.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="prop">The object to check for null.</param>
        /// <returns>The object if it is not null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the object is null.</exception>
        public static T ThrowIfNull<T>(this T prop)
        {
            if (prop is null)
            {
                throw new ArgumentNullException(nameof(prop));
            }
            return prop;
        }

        /// <summary>
        /// Throws a specified exception if the specified object is null.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <typeparam name="TException">The type of exception to be thrown.</typeparam>
        /// <param name="prop">The object to check for null.</param>
        /// <returns>The object if it is not null.</returns>
        /// <exception>Thrown when the object is null.</exception>
        public static T ThrowIfNull<T, TException>(this T prop)
            where TException : Exception
        {
            if (prop is null)
            {
                TException exception = Activator.CreateInstance(typeof(TException), nameof(prop)) as TException ?? throw new ApplicationException();
                throw exception;
            }
            return prop;
        }
    }
}