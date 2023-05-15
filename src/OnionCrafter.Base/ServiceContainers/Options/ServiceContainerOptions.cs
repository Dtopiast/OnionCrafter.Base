namespace OnionCrafter.Base.ServiceContainers.Options
{
    /// <summary>
    /// Implementation of the <see cref="IServiceContainerOptions{TLoggerOptions}"/> interface that uses a generic type <typeparamref name="TLoggerOptions"/> to configure a logger for a service container.
    /// </summary>
    /// <typeparam name="TLoggerOptions">The type of the logger options that will be used to configure the logger.</typeparam>
    public class ServiceContainerOptions<TLoggerOptions> : IServiceContainerOptions<TLoggerOptions>
    where TLoggerOptions : class, IServiceContainerLoggerOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceContainerOptions{TLoggerOptions}"/> class.
        /// </summary>
        public ServiceContainerOptions()
        {
            LoggerOptions = Activator.CreateInstance<TLoggerOptions>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use a logger for the service container.
        /// </summary>
        public bool UseLogger { get; set; }

        /// <summary>
        /// Gets or sets the logger options used to configure the logger for the service container.
        /// </summary>
        public TLoggerOptions LoggerOptions { get; set; }
    }
}