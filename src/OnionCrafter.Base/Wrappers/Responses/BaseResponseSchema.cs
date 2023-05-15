namespace OnionCrafter.Base.Wrappers.Responses
{
    /// <summary>
    /// Abstract base class for response schemas. Implements the <see cref="IResponseSchema{TKey, TResponseData}"/> interface.
    /// </summary>
    /// <typeparam name="TKey">The type of the action ID.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>

    public abstract class BaseResponseSchema<TKey, TResponseData>
        : IResponseSchema<TKey, TResponseData>
        where TResponseData : IResponseData
    {
        /// <summary>
        /// Initializes a new instance of the BaseResponseSchema class.
        /// </summary>
        protected BaseResponseSchema()
        {
            ActionId = Activator.CreateInstance<TKey>();
            Succeeded = false;
            Message = string.Empty;
            FeatureCall = string.Empty;
            TimeStamp = DateTime.UtcNow;
            ResponseData = Activator.CreateInstance<TResponseData>();
        }

        /// <summary>
        /// Gets or sets the action ID.
        /// </summary>
        public TKey ActionId { get; set; }

        /// <summary>
        /// Gets or sets the feature call associated with the response.
        /// </summary>
        public string FeatureCall { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the response data.
        /// </summary>
        public TResponseData ResponseData { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the response succeeded.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the response.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        public virtual IResponseSchema<TKey, TResponseData> ErrorResponse(string message)
        {
            if (message == string.Empty)
                Message = "Error";
            else
                Message = message;
            return this;
        }

        /// <summary>
        /// Sets the feature call associated with the response.
        /// </summary>
        /// <param name="request">The feature call name.</param>
        /// <returns>The response schema.</returns>
        public virtual IResponseSchema<TKey, TResponseData> SetFeatureCall(string request)
        {
            FeatureCall = request;
            return this;
        }

        /// <summary>
        /// Sets the message associated with the response.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The response schema.</returns>
        public virtual IResponseSchema<TKey, TResponseData> SetMessage(string message)
        {
            if (Succeeded)
                SuccesFullyResponse(message);
            else
                ErrorResponse(message);
            return this;
        }

        /// <summary>
        /// Sets the response data.
        /// </summary>
        /// <param name="data">The response data.</param>
        /// <returns>A boolean indicating the success of setting the response data.</returns>
        public virtual bool SetResponseData(TResponseData? data)
        {
            bool result = false;
            if (data != null)
            {
                ResponseData = data;
                SetSuccessfullyResult();
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Sets the response as a successful result.
        /// </summary>
        /// <returns>The response schema.</returns>
        public virtual IResponseSchema<TKey, TResponseData> SetSuccessfullyResult()
        {
            Succeeded = true;
            return this;
        }

        /// <summary>
        /// Creates a response schema with a success message.
        /// </summary>
        /// <param name="message">The success message.</param>
        /// <returns>The response schema.</returns>
        public virtual IResponseSchema<TKey, TResponseData> SuccesFullyResponse(string message)
        {
            if (message == string.Empty)
                Message = "Succeded";
            else
                Message = message;
            return this;
        }
    }
}