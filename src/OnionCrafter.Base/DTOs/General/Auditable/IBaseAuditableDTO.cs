using OnionCrafter.Base.Commons;

namespace OnionCrafter.Base.DTOs.General.Auditable
{
    /// <summary>
    /// Represents an interface for an auditable Data Transfer Object (DTO) that includes auditing properties.
    /// </summary>
    public interface IBaseAuditableDTO :
        IBaseDTO, IAuditableClass
    {
    }
}