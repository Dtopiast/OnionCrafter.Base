namespace OnionCrafter.Base.Commons
{
    /// <summary>
    /// Interface for auditable classes.
    /// </summary>
    public interface IAuditableClass
    {
        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the last updated date.
        /// </summary>
        public DateTime Updated { get; set; }
    }
}