using OnionCrafter.Base.Wrappers.Requests;

namespace OnionCrafter.Base.DTOs
{
    /// <summary>
    /// Abstract base class for an auditable request Data Transfer Object (DTO).
    /// </summary>
    public abstract class BaseRequestAuditableDTO : BaseAuditableDTO, IRequestData
    {
    }
}