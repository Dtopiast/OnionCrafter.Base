using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests.Query
{
    public abstract class BaseQueryRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> : BaseRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>, IQueryRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData
    {
        public bool BypassCache { get; }
        public string CacheKey { get; }
        public TimeSpan? SlidingExpiration { get; }

        protected BaseQueryRequestSchema()
        {
            CacheKey = string.Empty;
        }
    }
}