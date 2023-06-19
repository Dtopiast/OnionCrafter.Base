namespace OnionCrafter.Base.Entities
{
    /// <summary>
    /// Abstract base class for entities with a key.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's key.</typeparam>
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <inheritdoc/>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity{TKey}"/> class.
        /// </summary>
        protected BaseEntity()
        {
            Id = Activator.CreateInstance<TKey>();
        }

        /// <inheritdoc/>
        public abstract void CreateRandomId();

        /// <inheritdoc/>
        public void SetId(TKey key)
        {
            Id = key;
        }
    }

    /// <summary>
    /// Abstract base class for entities with a string key.
    /// </summary>
    public abstract class BaseEntity : BaseEntity<string>, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        protected BaseEntity()
        {
            Id = string.Empty;
        }
    }
}