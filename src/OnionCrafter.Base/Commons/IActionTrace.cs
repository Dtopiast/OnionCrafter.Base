namespace OnionCrafter.Base.Commons
{
    /// <summary>
    /// Interface for tracing actions with a generic key.
    /// </summary>
    public interface IActionTrace<TKey>
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Set or get the tracing action Id
        /// </summary>
        public TKey ActionId { get; set; }

        /// <summary>
        /// Sets the action Id using the provided key.
        /// </summary>
        /// <param name="key">The key to set as the action Id.</param>

        public abstract void SetActionId(TKey key);

        /// <summary>
        /// Creates a new action Id.
        /// </summary>
        public abstract void CreateActionId();
    }
}