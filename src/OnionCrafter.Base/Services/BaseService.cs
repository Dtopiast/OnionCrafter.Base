using Microsoft.Extensions.Options;
using OnionCrafter.Base.Services.Options;

namespace OnionCrafter.Base.Services
{
    /// <summary>
    ///Abstract implementation of the <see cref=IService"/>.
    /// </summary>
    public abstract class BaseService : IService
    {
        /// <summary>
        /// Creates a shallow copy of the service.
        /// </summary>
        /// <returns>A cloned instance of the service.</returns>
        public abstract T Clone<T>()
            where T : IService;

        /// <summary>
        /// Disposes the service asynchronously.
        /// </summary>
        public abstract ValueTask DisposeAsync();
    }

    /// <summary>
    ///Abstract implementation of the <see cref=IService<TServiceOptions>"/> with options.
    /// </summary>
    /// <typeparam name="TServiceOptions">The type of service options.</typeparam>
    public abstract class BaseService<TServiceOptions> : BaseService, IService<TServiceOptions>
        where TServiceOptions : class, IServiceOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TServiceOptions}"/> class.
        /// </summary>
        /// <param name="config">The service options configuration.</param>
        protected BaseService(IOptions<TServiceOptions> config)
        {
            Config = config.Value;
        }

        /// <summary>
        /// Gets the service options.
        /// </summary>
        public TServiceOptions Config { get; }
    }
}