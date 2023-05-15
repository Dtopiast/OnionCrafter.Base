namespace OnionCrafter.Base.Commons
{
    /// <summary>
    /// Represents an interface for copying objects of type T.
    /// </summary>
    /// <typeparam name="T">The type of object to be copied.</typeparam>
    public interface ICopyable<T>
    {
        /// <summary>
        /// Copies the properties of the specified object to the current instance.
        /// </summary>
        /// <param name="toCopy">The object to copy.</param>
        public void CopyTo(T toCopy);
    }
}