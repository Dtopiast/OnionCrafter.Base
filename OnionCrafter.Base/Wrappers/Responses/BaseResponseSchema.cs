namespace OnionCrafter.Base.Wrappers.Responses
{
    public abstract class BaseResponseSchema<TKey, TResponseData>
        : IResponseSchema<TKey, TResponseData>
        where TResponseData : IResponseData
    {
        protected BaseResponseSchema()
        {
            ActionId = Activator.CreateInstance<TKey>();
            Succeeded = false;
            Message = string.Empty;
            FeatureCall = string.Empty;
            TimeStamp = DateTime.UtcNow;
            ResponseData = Activator.CreateInstance<TResponseData>();
        }

        public TKey ActionId { get; set; }
        public string FeatureCall { get; set; }
        public string Message { get; set; }
        public TResponseData ResponseData { get; set; }
        public bool Succeeded { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual IResponseSchema<TKey, TResponseData> SetFeatureCall(string request)
        {
            FeatureCall = request;
            return this;
        }

        public virtual IResponseSchema<TKey, TResponseData> SetMessage(string message)
        {
            if (Succeeded)
                SuccesFullyResponse(message);
            else
                ErrorResponse(message);
            return this;
        }

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

        public virtual IResponseSchema<TKey, TResponseData> SetSuccessfullyResult()
        {
            Succeeded = true;
            return this;
        }

        public virtual IResponseSchema<TKey, TResponseData> ErrorResponse(string message)
        {
            if (message == string.Empty)
                Message = "Error";
            else
                Message = message;
            return this;
        }

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