﻿using OnionCrafter.Base.Wrappers.Requests.General;
using OnionCrafter.Base.Wrappers.Responses.General;

namespace OnionCrafter.Base.Wrappers.Requests.General.Query
{
    /// <summary>
    /// Represents a query request schema that inherits from IRequestSchema.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TResponseSchema">The type of the response schema.</typeparam>
    /// <typeparam name="TReturnData">The type of the return data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>
    public interface IQueryRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> :
        IRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
    }
}