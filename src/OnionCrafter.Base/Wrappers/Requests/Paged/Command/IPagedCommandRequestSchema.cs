using OnionCrafter.Base.Wrappers.Requests.General;
using OnionCrafter.Base.Wrappers.Requests.General.Command;
using OnionCrafter.Base.Wrappers.Requests.Paged;
using OnionCrafter.Base.Wrappers.Responses.General;

namespace OnionCrafter.Base.Wrappers.Requests.Paged.Command
{
    /// <summary>
    /// Represents an interface for paged command request schemas.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TResponseSchema">The type of the response schema.</typeparam>
    /// <typeparam name="TReturnData">The type of the return data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>
    public interface IPagedCommandRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> :
        ICommandRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>,
        IPagedRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
    }
}