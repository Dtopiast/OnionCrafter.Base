using OnionCrafter.Base.Wrappers.Responses;

namespace OnionCrafter.Base.DTO
{
    public abstract class BaseResponseAuditableDTO : BaseResponseDTO, IAuditableDTO
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}