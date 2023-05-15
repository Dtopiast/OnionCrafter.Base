using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnionCrafter.Base.Services.Options;
using OnionCrafter.Base.Utils;

namespace OnionCrafter.Base.Services
{
    /// <summary>
    ///Abstract implementation of the <see cref=IService"/> with default general settings.
    /// </summary>
    public abstract class BaseService : BaseService<GlobalServiceOptions>
    {
        protected BaseService(IOptionsMonitor<GlobalServiceOptions> optionsMonitor, ILogger<BaseService<GlobalServiceOptions>>? logger) : base(optionsMonitor, logger)
        {
        }
    }

    /// <summary>
    ///Abstract implementation of the <see cref=IService"/>.
    /// </summary>
    public abstract class BaseService<TGlobalServiceOptions> : IService
        where TGlobalServiceOptions : class, IGlobalServiceOptions
    {
        /// <summary>
        /// Field to store a logger instance.
        /// </summary>
        protected readonly ILogger? _logger;

        /// <summary>
        /// Flag indicating whether to use a logger or not.
        /// </summary>
        protected bool _useLogger;

        /// <summary>
        /// Field to store the global service options.
        /// </summary>
        protected TGlobalServiceOptions _globalServiceOptions;

        /// <summary>
        /// Constructor for BaseService class which takes IOptionsMonitor and ILogger as parameters.
        /// </summary>
        protected BaseService(IOptionsMonitor<TGlobalServiceOptions> optionsMonitor, ILogger<BaseService<TGlobalServiceOptions>>? logger)
        {
            _logger = logger;
            _globalServiceOptions = optionsMonitor.Get(Environment.GetEnvironmentVariable("GlobalServiceConfiguration"));
            _useLogger = _globalServiceOptions.UseLogger;
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

        public abstract void LogAction<TServiceAction>(bool actionResult, TServiceAction action, params object?[] args)
            where TServiceAction : struct, Enum;
    }

    /// <summary>
    ///Abstract implementation of the <see cref=IService{TServiceOptions}"/> with options.
    /// </summary>
    /// <typeparam name="TServiceOptions">The type of service options.</typeparam>
    public abstract class BaseService<TGlobalServiceOptions, TServiceOptions> : BaseService<TGlobalServiceOptions>, IService<TServiceOptions>
                where TGlobalServiceOptions : class, IGlobalServiceOptions

        where TServiceOptions : class, IServiceOptions
    {
        /// <summary>
        /// Constructor for BaseService class.
        /// </summary>
        /// <param name="optionsMonitor">Options monitor for global service options.</param>
        /// <param name="logger">Logger for the service.</param>
        /// <param name="config">Options for the service.</param>
        /// <returns>
        /// An instance of the BaseService class.
        /// </returns>
        protected BaseService(IOptionsMonitor<TGlobalServiceOptions> optionsMonitor, ILogger<BaseService<TGlobalServiceOptions>>? logger, IOptions<TServiceOptions> config) : base(optionsMonitor, logger)
        {
            Config = config.Value;
            _useLogger = Config.UseLogger;
            Name = Config.SetServiceName ?? Name;
            _logger.CheckLoggerImplementation(_useLogger);
        }

        /// <summary>
        /// Gets the service options.
        /// </summary>
        public TServiceOptions Config { get; }
    }
}