namespace OnionCrafter.Base.Entities
{
    /// <summary>
    /// Base class for auditable entities with a given key type.
    /// Implements the IAuditableEntity interface.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's primary key.</typeparam>
    public abstract class BaseAuditableEntity<TKey> : IAuditableEntity<TKey>
    where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAuditableEntity{TKey}"/> class.
        /// </summary>
        protected BaseAuditableEntity()
        {
            Id = Activator.CreateInstance<TKey>();
        }

        /// <summary>
        /// Gets or sets the date the entity was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the entity's primary key.
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Gets or sets the date the entity was last updated.
        /// </summary>
        public DateTime Updated { get; set; }
    }

    /// <summary>
    /// Base class for auditable entities with a string primary key.
    /// Implements the IAuditableEntity interface.
    /// </summary>
    public abstract class BaseAuditableEntity : IAuditableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAuditableEntity"/> class.
        /// </summary>
        protected BaseAuditableEntity()
        {
            Id = string.Empty;
        }

        /// <summary>
        /// Gets or sets the date the entity was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the entity's primary key.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date the entity was last updated.
        /// </summary>
        public DateTime Updated { get; set; }
    }
}