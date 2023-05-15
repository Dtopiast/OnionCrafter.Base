namespace OnionCrafter.Base.Services.Options
{
    /// <summary>
    /// Represents the global service options.
    /// </summary>
    public class GlobalServiceOptions : IGlobalServiceOptions
    {
        /// <summary>
        ///  /// Gets or sets a value indicating whether to use a logger.
        /// </summary>
        public bool UseLogger { get; set; }
    }
}