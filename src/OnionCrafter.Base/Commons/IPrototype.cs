namespace OnionCrafter.Base.Commons
{
    /// <summary>
    /// Represents an interface for cloning objects of a specific type.
    /// </summary>
    /// <typeparam name="T">The type of the object to be cloned.</typeparam>
    public interface IPrototype<T>
    {
        /// <summary>
        /// Creates a shallow copy of the object.
        /// </summary>
        /// <typeparam name="TReturn">The type of the cloned object.</typeparam>
        /// <returns>A new instance of the cloned object.</returns>
        TReturn Clone<TReturn>()
            where TReturn : T;
    }
}