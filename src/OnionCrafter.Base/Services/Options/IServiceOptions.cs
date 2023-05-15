namespace OnionCrafter.Base.Services.Options
{
    /// <summary>
    /// Interface for service options.
    /// </summary>
    public interface IServiceOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether to use a logger.
        /// </summary>
        public bool UseLogger { get; set; }

        public string? SetServiceName { get; set; }
    }
}