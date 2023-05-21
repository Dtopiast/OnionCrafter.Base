using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests
{
    /// <summary>
    /// Enum to represent the type of request.
    /// </summary>
    public enum RequestType
    {
        NoSpecificate = 0,
        Query,
        Command
    }

    /// <summary>
    /// Base abstract class for defining request schema used in MediatR requests. Implements the <see cref="IRequestSchema{TKey, TResponseSchema, TReturnData, TRequestData}"/> interface.
    /// It defines generic types for Action Id, Response Schema, Return Data, and Request Data.
    /// </summary>
    /// <typeparam name="TKey">Type of Action Id.</typeparam>
    /// <typeparam name="TResponseSchema">Type of Response Schema.</typeparam>
    /// <typeparam name="TReturnData">Type of Return Data.</typeparam>
    /// <typeparam name="TRequestData">Type of Request Data.</typeparam>
    public abstract class BaseRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> : IRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
         where TResponseSchema : IResponseSchema<TKey, TReturnData>
         where TReturnData : IResponseData
         where TRequestData : IRequestData
         where TKey : notnull, IEquatable<TKey>, IComparable<TKey>


    {
        /// <summary>
        /// Represents the feature call and its corresponding implementation names.
        /// </summary>
        protected string featureCall;

        /// <summary>
        /// Dictionary that maps the RequestType to its corresponding implementation name.
        /// </summary>
        protected readonly Dictionary<RequestType, string> _featureImplementationNames = new Dictionary<RequestType, string>()
        {
           {RequestType.NoSpecificate, "Async" },
           {RequestType.Query, "Query"},
           {RequestType.Command, "Command"}
        };

        /// <summary>
        /// Action Id for the request.
        /// </summary>
        public TKey ActionId { get; set; }

        /// <summary>
        /// Request data for the request.
        /// </summary>
        public TRequestData RequestData { get; set; }

        /// <summary>
        /// Type of request.
        /// </summary>
        public RequestType RequestType { get; set; }

        /// <summary>
        /// Constructor for setting default values for Action Id, Request Data, and feature call.
        /// </summary>
        protected BaseRequestSchema()
        {
            ActionId = Activator.CreateInstance<TKey>();
            RequestData = Activator.CreateInstance<TRequestData>();
            featureCall = string.Empty;
            SetFeatureCall();
        }

        /// <summary>
        /// Method to get request feature call name.
        /// </summary>
        /// <returns>Feature call for the request.</returns>

        public string GetRequestFeature()
        {
            return featureCall;
        }

        /// <summary>
        /// Method to set feature call name for the request.
        /// </summary>
        /// <returns>True if feature call is set successfully.</returns>

        public bool SetFeatureCall()
        {
            string nameOfClass = GetType().Name;
            foreach ((var key, string value) in _featureImplementationNames)
            {
                if (nameOfClass.Contains(value))
                {
                    featureCall = nameOfClass.Replace(value, string.Empty);
                    RequestType = key;
                }
            }
            return true;
        }

        /// <summary>
        /// Method to set feature call name for the request with the given name.
        /// </summary>
        /// <param name="name">Feature call name to be set for the request.</param>
        /// <returns>True if feature call is set successfully.</returns>

        public bool SetFeatureCall(string name)
        {
            featureCall = name;
            return true;
        }

        /// <summary>
        /// Method to set request data for the request.
        /// </summary>
        /// <param name="requestData">Request data to be set for the request.</param>
        /// <returns>True if request data is set successfully.</returns>
        public bool SetRequestData(TRequestData requestData)
        {
            RequestData = requestData;
            return true;
        }

        /// <summary>
        /// Copies the values of this request schema to the given request schema.
        /// </summary>
        /// <param name="toCopy">The IRequestSchema object to copy.</param>
        public void CopyTo(IRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> toCopy)
        {
            toCopy.ActionId = ActionId;
            toCopy.RequestData = RequestData;
            toCopy.RequestType = RequestType;
        }

        /// <summary>
        /// Copies the values of this request schema to the given ResponseSchema.
        /// </summary>
        public void CopyTo(TResponseSchema toCopy)
        {
            toCopy.FeatureCall = featureCall;
            toCopy.ActionId = ActionId;
        }
    }
}