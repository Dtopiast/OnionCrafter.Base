using OnionCrafter.Base.Wrappers.Common;
using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests
{
    public interface IRequestSchema<TKey, TResponseSchema, TResponseData, TRequestData> : MediatR.IRequest<TResponseSchema>, IBaseRequest, IActionTrace<TKey>
        where TResponseSchema : IResponseSchema<TKey, TResponseData>
        where TResponseData : IResponseData
        where TRequestData : IRequestData
    {
        public TRequestData RequestData { get; set; }

        protected RequestType requestType { get; set; }

        public string GetRequestFeature();

        public bool SetFeatureCall();

        public bool SetRequestData(TRequestData requestData);

        public bool SetFeatureCall(string name);
    }
}