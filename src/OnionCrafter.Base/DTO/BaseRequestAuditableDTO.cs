namespace OnionCrafter.Base.DTO
{
    public abstract class BaseRequestAuditableDTO : BaseRequestDTO, IAuditableDTO
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}