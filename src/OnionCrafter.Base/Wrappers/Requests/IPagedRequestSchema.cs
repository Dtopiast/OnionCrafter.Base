using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests
{
    /// <summary>
    /// Represents a paged request schema that inherits from <see cref="IRequestSchema{TKey, TResponseSchema, TResponseData, TRequestData}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the key for the request schema.</typeparam>
    /// <typeparam name="TResponseSchema">The type of the response schema for the request schema.</typeparam>
    /// <typeparam name="TReturnData">The type of the response data for the request schema.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data for the request schema.</typeparam>
    public interface IPagedRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> : IRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Gets or sets the page number for the paged request.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size for the paged request.
        /// </summary>
        public int PageSize { get; set; }
    }
}