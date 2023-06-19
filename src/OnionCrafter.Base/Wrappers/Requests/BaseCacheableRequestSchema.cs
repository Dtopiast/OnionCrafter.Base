using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests
{
    /// <summary>
    /// Represents a base class for cacheable request schemas.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TResponseSchema">The type of the response schema.</typeparam>
    /// <typeparam name="TReturnData">The type of the return data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>
    public abstract class BaseCacheableRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> :
        BaseRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>,
        ICacheableRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCacheableRequestSchema{TKey, TResponseSchema, TReturnData, TRequestData}"/> class.
        /// </summary>
        /// <param name="cacheKey">The cache key associated with the request.</param>
        protected BaseCacheableRequestSchema(string cacheKey)
        {
            CacheKey = cacheKey;
        }

        ///<inheritdoc/>
        public bool BypassCache { get; set; }

        ///<inheritdoc/>
        public string CacheKey { get; }

        ///<inheritdoc/>
        public TimeSpan? SlidingExpiration { get; set; }
    }
}