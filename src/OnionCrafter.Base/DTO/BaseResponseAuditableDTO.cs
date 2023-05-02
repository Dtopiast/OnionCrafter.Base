using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.DTO
{
    public abstract class BaseResponseAuditableDTO : IAuditableDTO, IResponseData
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}