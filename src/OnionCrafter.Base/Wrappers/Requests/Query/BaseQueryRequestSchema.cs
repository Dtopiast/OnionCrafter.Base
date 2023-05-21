using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests.Query
{
    /// <summary>
    /// Base class for query request schemas that includes caching-related properties and inherits from BaseRequestSchema.
    /// </summary>
    /// <typeparam name="TKey">The type for the request's unique identifier.</typeparam>
    /// <typeparam name="TResponseSchema">The type for the response schema.</typeparam>
    /// <typeparam name="TReturnData">The type for the response data.</typeparam>
    /// <typeparam name="TRequestData">The type for the request data.</typeparam>
    public abstract class BaseQueryRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> : BaseRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>, IQueryRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Determines whether to bypass the cache for this request.
        /// </summary>
        public bool BypassCache { get; }

        /// <summary>
        /// The cache key for this request.
        /// </summary>
        public string CacheKey { get; }

        /// <summary>
        /// The sliding expiration for the cached data, if any.
        /// </summary>
        public TimeSpan? SlidingExpiration { get; }

        /// <summary>
        /// Initializes a new instance of the BaseQueryRequestSchema class.
        /// </summary>
        protected BaseQueryRequestSchema()
        {
            CacheKey = string.Empty;
        }
    }
}