namespace OnionCrafter.Base.Entities
{
    /// <summary>
    /// Abstract base class for entities with a key.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's key.</typeparam>
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Gets or sets the entity's key.
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity{TKey}"/> class.
        /// </summary>
        protected BaseEntity()
        {
            Id = Activator.CreateInstance<TKey>();
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