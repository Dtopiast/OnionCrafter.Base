namespace OnionCrafter.Base.Entities
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }

        protected BaseEntity()
        {
            Id = Activator.CreateInstance<TKey>();
        }
    }

    public abstract class BaseEntity : IEntity<string>
    {
        public virtual string Id { get; set; }

        protected BaseEntity()
        {
            Id = string.Empty;
        }
    }
}