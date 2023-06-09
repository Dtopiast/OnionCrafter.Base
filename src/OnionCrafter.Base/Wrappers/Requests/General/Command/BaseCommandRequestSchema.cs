﻿using OnionCrafter.Base.Wrappers.Requests.General;
using OnionCrafter.Base.Wrappers.Responses.General;

namespace OnionCrafter.Base.Wrappers.Requests.General.Command
{
    /// <summary>
    /// Represents a base class for implementing command request schemas. Inherits from BaseRequestSchema and implements ICommandRequestSchema.
    /// </summary>
    /// <typeparam name="TKey">The type of the action ID.</typeparam>
    /// <typeparam name="TResponseSchema">The type of the response schema.</typeparam>
    /// <typeparam name="TReturnData">The type of the return data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>
    public abstract class BaseCommandRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> :
        BaseRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>,
        ICommandRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
            where TResponseSchema : IResponseSchema<TKey, TReturnData>
            where TReturnData : IResponseData
            where TRequestData : IRequestData
            where TKey : notnull, IEquatable<TKey>, IComparable<TKey>

    {
        /// <summary>
        /// Protected parameterless constructor for BaseCommandRequestSchema class.
        /// </summary>
        protected BaseCommandRequestSchema()
        {
        }
    }
}