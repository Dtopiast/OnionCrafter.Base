using OnionCrafter.Base.Commons;

namespace OnionCrafter.Base.Wrappers.Responses.General
{
    /// <summary>
    /// Represents a response schema. Inherits from <see cref=" IActionTrace{TKey}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the action ID.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>
    public interface IResponseSchema<TKey, TResponseData> :
        IBaseResponseSchema,
        IActionTrace<TKey>
        where TResponseData : IResponseData
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
    {
        /// <summary>
        /// Gets or sets the feature call associated with the response.
        /// </summary>
        public string FeatureCall { get; protected set; }

        /// <summary>
        /// Gets or sets the message associated with the response.
        /// </summary>
        public string Message { get; protected set; }

        /// <summary>
        /// Gets or sets the response data.
        /// </summary>
        public TResponseData ResponseData { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether the response succeeded.
        /// </summary>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// Gets or sets the timestamp of the response.
        /// </summary>
        public DateTime TimeStamp { get; protected set; }

        /// <summary>
        /// Handles an error response with the specified message.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> ErrorResponse(string message);

        /// <summary>
        /// Sets the feature call associated with the response.
        /// </summary>
        /// <param name="featureName">The feature call name.</param>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> SetFeatureCall(string featureName);

        /// <summary>
        /// Sets the message associated with the response.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> SetMessage(string message);

        /// <summary>
        /// Sets the response data.
        /// </summary>
        /// <param name="data">The response data.</param>
        /// <returns>A boolean indicating the success of setting the response data.</returns>
        public abstract bool SetResponseData(TResponseData? data);

        /// <summary>
        /// Sets the response as a successful result.
        /// </summary>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> SetSuccessfullyResult();

        /// <summary>
        /// Handles a successful response with the specified message.
        /// </summary>
        /// <param name="message">The success message.</param>
        /// <returns>The response schema.</returns>
        public abstract IResponseSchema<TKey, TResponseData> SuccesFullyResponse(string message);
    }
}