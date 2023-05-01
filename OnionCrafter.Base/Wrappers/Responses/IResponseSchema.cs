namespace OnionCrafter.Base.Wrappers.Responses
{
    public interface IResponseSchema<TKey, TResponseData>
        where TResponseData : IResponseData
    {
        public TKey ActionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string FeatureCall { get; set; }
        public TResponseData ResponseData { get; set; }

        public abstract bool SetResponseData(TResponseData? data);

        public abstract IResponseSchema<TKey, TResponseData> SetSuccessfullyResult();

        public abstract IResponseSchema<TKey, TResponseData> SetFeatureCall(string featureName);

        public abstract IResponseSchema<TKey, TResponseData> SetMessage(string message);

        protected abstract IResponseSchema<TKey, TResponseData> ErrorResponse(string message);

        protected abstract IResponseSchema<TKey, TResponseData> SuccesFullyResponse(string message);
    }
}