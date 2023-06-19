using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests
{
    /// <summary>
    /// Represents an interface for cacheable request schemas.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TResponseSchema">The type of the response schema.</typeparam>
    /// <typeparam name="TReturnData">The type of the return data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>

    public interface ICacheableRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> : IBaseCacheableRequestSchema
       where TResponseSchema : IResponseSchema<TKey, TReturnData>
       where TReturnData : IResponseData
       where TRequestData : IRequestData
       where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
    }
}