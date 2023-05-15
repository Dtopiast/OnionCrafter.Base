using OnionCrafter.Base.Commons;
using OnionCrafter.Base.Services.Options;

namespace OnionCrafter.Base.Services
{
    /// <summary>
    /// Interface for a service.
    /// </summary>
    public interface IService : IBaseService
    {
        public string Name { get; protected set; }
    }

    /// <summary>
    /// Interface for a service with specific options.
    /// </summary>
    /// <typeparam name="TServiceOptions">The type of options for the service.</typeparam>
    public interface IService<TServiceOptions> : IService
        where TServiceOptions : IServiceOptions
    {
        /// <summary>
        /// Gets the configuration options for the service.
        /// </summary>
        public TServiceOptions Config { get; }
    }
}