using OnionCrafter.Base.Wrappers.Requests.General;
using OnionCrafter.Base.Wrappers.Responses.General;

namespace OnionCrafter.Base.Wrappers.Requests.Paged
{
    /// <summary>
    /// Represents an abstract base class for paged request schemas.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TResponseSchema">The type of the response schema.</typeparam>
    /// <typeparam name="TReturnData">The type of the return data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>
    public abstract class BasePagedRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> :
        BaseRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>,
        IPagedRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
         where TResponseSchema : IResponseSchema<TKey, TReturnData>
         where TReturnData : IResponseData
         where TRequestData : IRequestData
         where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        ///<inheritdoc/>
        public int PageNumber { get; set; }

        ///<inheritdoc/>

        public int PageSize { get; set; }
    }
}