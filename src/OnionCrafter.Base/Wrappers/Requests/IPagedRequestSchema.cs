using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests
{
    public interface IPagedRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> : IRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData

    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}