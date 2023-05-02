using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests
{
    public enum RequestType
    {
        NoSpecificate = 0,
        Query,
        Command
    }

    public abstract class BaseRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> : IRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
         where TResponseSchema : IResponseSchema<TKey, TReturnData>
         where TReturnData : IResponseData
         where TRequestData : IRequestData

    {
        protected string featureCall;

        protected readonly Dictionary<RequestType, string> _featureImplementationNames = new Dictionary<RequestType, string>()
        {
            {RequestType.NoSpecificate, "Async" },
            {RequestType.Query, "Query"},
            {RequestType.Command, "Command"}
        };

        public TKey ActionId { get; set; }
        public TRequestData RequestData { get; set; }

        public RequestType requestType { get; set; }

        protected BaseRequestSchema()
        {
            ActionId = Activator.CreateInstance<TKey>();
            RequestData = Activator.CreateInstance<TRequestData>();
            featureCall = string.Empty;
            SetFeatureCall();
        }

        public string GetRequestFeature()
        {
            return featureCall;
        }

        public bool SetFeatureCall()
        {
            string nameOfClass = GetType().Name;
            foreach ((var key, string value) in _featureImplementationNames)
            {
                if (nameOfClass.Contains(value))
                {
                    featureCall = nameOfClass.Replace(value, string.Empty);
                    requestType = key;
                }
            }
            return true;
        }

        public bool SetFeatureCall(string name)
        {
            featureCall = name;
            return true;
        }

        public bool SetRequestData(TRequestData requestData)
        {
            RequestData = requestData;
            return true;
        }
    }
}