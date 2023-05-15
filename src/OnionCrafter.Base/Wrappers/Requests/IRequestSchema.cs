using OnionCrafter.Base.Commons;
using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests
{
    /// <summary>
    /// Interface representing a request schema that defines the contract for a MediatR request object, as well as additional properties and methods for tracing and feature management.
    /// </summary>
    /// <typeparam name="TKey">The type of the request key.</typeparam>
    /// <typeparam name="TResponseSchema">The type of the response schema.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>
    public interface IRequestSchema<TKey, TResponseSchema, TResponseData, TRequestData> : MediatR.IRequest<TResponseSchema>, IBaseRequest, IActionTrace<TKey>, ICopyable<IRequestSchema<TKey, TResponseSchema, TResponseData, TRequestData>>, ICopyable<TResponseSchema>
        where TResponseSchema : IResponseSchema<TKey, TResponseData>
        where TResponseData : IResponseData
        where TRequestData : IRequestData
    {
        /// <summary>
        /// Gets or sets the request data.
        /// </summary>
        TRequestData RequestData { get; set; }

        /// <summary>
        /// Gets or sets the type of the request.
        /// </summary>
        public RequestType RequestType { get; set; }

        /// <summary>
        /// Gets the feature of the request.
        /// </summary>
        /// <returns>The feature of the request.</returns>
        public string GetRequestFeature();

        /// <summary>
        /// Sets the feature call of the request.
        /// </summary>
        /// <returns>True if the feature call was set successfully; otherwise, false.</returns>
        public bool SetFeatureCall();

        /// <summary>
        /// Sets the request data of the request.
        /// </summary>
        /// <param name="requestData">The request data to set.</param>
        /// <returns>True if the request data was set successfully; otherwise, false.</returns>
        public bool SetRequestData(TRequestData requestData);

        /// <summary>
        /// Sets the feature call of the request with a specific name.
        /// </summary>
        /// <param name="name">The name of the feature call to set.</param>
        /// <returns>True if the feature call was set successfully; otherwise, false.</returns>
        public bool SetFeatureCall(string name);
    }
}