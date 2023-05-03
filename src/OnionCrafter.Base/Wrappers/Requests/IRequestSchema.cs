using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests
{
    public interface IRequestSchema<TKey, TResponseSchema, TResponseData, TRequestData> : MediatR.IRequest<TResponseSchema>, IBaseRequest
        where TResponseSchema : IResponseSchema<TKey, TResponseData>
        where TResponseData : IResponseData
        where TRequestData : IRequestData
    {
        public TKey ActionId { get; set; }

        public TRequestData RequestData { get; set; }

        protected RequestType requestType { get; set; }

        public string GetRequestFeature();

        public bool SetFeatureCall();

        public bool SetRequestData(TRequestData requestData);

        public bool SetFeatureCall(string name);
    }
}