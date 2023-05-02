using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests.Query
{
    public interface IQueryRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> : IRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>, ICacheableRequestSchema
        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData
    {
    }
}