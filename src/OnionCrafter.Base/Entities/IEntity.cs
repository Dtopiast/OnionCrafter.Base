namespace OnionCrafter.Base.Entities
{
    /// <summary>
    /// Represents an entity with a unique identifier of type <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the unique identifier.</typeparam>
    /// <seealso cref="IBaseEntity" />
    public interface IEntity<TKey> : IBaseEntity
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the entity.
        /// </summary>
        public TKey Id { get; set; }
    }

    /// <summary>
    /// Interface for entities without a specific key type, using a string as the key type.
    /// </summary>
    public interface IEntity : IEntity<string>
    {
    }
}