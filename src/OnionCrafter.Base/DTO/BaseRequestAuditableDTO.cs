namespace OnionCrafter.Base.DTO
{
    public abstract class BaseRequestAuditableDTO : IAuditableDTO
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}