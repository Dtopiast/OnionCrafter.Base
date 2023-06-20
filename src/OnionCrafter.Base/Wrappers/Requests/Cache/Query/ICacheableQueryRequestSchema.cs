using OnionCrafter.Base.Wrappers.Requests.Cache;
using OnionCrafter.Base.Wrappers.Requests.General;
using OnionCrafter.Base.Wrappers.Requests.General.Query;
using OnionCrafter.Base.Wrappers.Responses.General;

namespace OnionCrafter.Base.Wrappers.Requests.Cache.Query
{
    /// <summary>
    /// Represents an interface for cacheable query request schemas.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TResponseSchema">The type of the response schema.</typeparam>
    /// <typeparam name="TReturnData">The type of the return data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>

    public interface ICacheableQueryRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> :
        IQueryRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>,
        ICacheableRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
    }
}