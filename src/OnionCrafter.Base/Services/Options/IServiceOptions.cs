using OnionCrafter.Base.Commons;

namespace OnionCrafter.Base.Services.Options
{
    /// <summary>
    /// Interface for service options.
    /// </summary>
    public interface IServiceOptions : IUseLogger
    {
        /// <summary>
        /// Property to get and set the service name.
        /// </summary>
        public string? SetServiceName { get; set; }
    }
}