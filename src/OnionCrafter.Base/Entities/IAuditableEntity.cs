using OnionCrafter.Base.Commons;

namespace OnionCrafter.Base.Entities
{
    /// <summary>
    /// Interface for auditable entities that inherit from an entity with a key.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's key.</typeparam>
    public interface IAuditableEntity<TKey> : IEntity<TKey>, IAuditableClass
    where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
    }

    /// <summary>
    /// Interface for auditable entities without a specified key type, inheriting from <see cref="IAuditableEntity{TKey}"/> with <see cref="string"/> as the key type.
    /// </summary>
    public interface IAuditableEntity : IAuditableEntity<string>
    {
    }
}