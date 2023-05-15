using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnionCrafter.Base.Services.Options;
using OnionCrafter.Base.Utils;

namespace OnionCrafter.Base.Services
{
    /// <summary>
    ///Abstract implementation of the <see cref=IService"/>.
    /// </summary>
    public abstract class BaseService : IService
    {
        /// <summary>
        /// Field to store a logger instance.
        /// </summary>
        protected ILogger? _logger;

        /// <summary>
        /// Constructor for BaseService class with an optional ILogger parameter.
        /// </summary>
        protected BaseService(ILogger<BaseService>? logger)
        {
            _logger = logger;
            Name = GetType().Name;
        }

        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        public string Name { get; set; }

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
        protected BaseService(ILogger<BaseService>? logger, IOptions<TServiceOptions> config) : base(logger)
        {
            Config = config.Value;
            Name = Config.SetServiceName ?? Name;
            _logger.CheckLoggerImplementation(Config.UseLogger);
        }

        /// <summary>
        /// Gets the service options.
        /// </summary>
        public TServiceOptions Config { get; }
    }
}