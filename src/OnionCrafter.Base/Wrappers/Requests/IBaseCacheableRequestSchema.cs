namespace OnionCrafter.Base.Wrappers.Requests
{
    /// <summary>
    ///  Interface for cacheable base request schemas,
    /// </summary>
    public interface IBaseCacheableRequestSchema : IBaseRequestSchema
    {
        /// <summary>
        /// Gets a boolean value indicating whether to bypass cache.
        /// </summary>
        bool BypassCache { get; }

        /// <summary>
        /// Gets a string representing the cache key for this request.
        /// </summary>
        string CacheKey { get; }

        /// <summary>
        /// Gets or sets a nullable TimeSpan representing the sliding expiration for this request.
        /// </summary>
        TimeSpan? SlidingExpiration { get; }
    }
}