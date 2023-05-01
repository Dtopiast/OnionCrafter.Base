using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.Wrappers.Requests.Command
{
    public abstract class BaseCommandRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData> : BaseRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>, ICommandRequestSchema<TKey, TResponseSchema, TReturnData, TRequestData>
        where TResponseSchema : IResponseSchema<TKey, TReturnData>
        where TReturnData : IResponseData
        where TRequestData : IRequestData
    {
        protected BaseCommandRequestSchema()
        {
        }
    }
}