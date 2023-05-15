using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnionCrafter.Base.DataAccess;
using OnionCrafter.Base.ServiceContainers.Options;
using OnionCrafter.Base.Services;
using OnionCrafter.Base.Utils;

namespace OnionCrafter.Base.ServiceContainers
{
    /// <summary>
    /// Abstract implementation of the <see cref="IServiceContainer<TKey, TValue, TContainerOptions, TContainerLoggerOptions>"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the key to identify the services.</typeparam>
    /// <typeparam name="TValue">The type of the services to store.</typeparam>
    /// <typeparam name="TContainerOptions">The type of options for the service container.</typeparam>
    /// <typeparam name="TContainerLoggerOptions">The type of options for the service container logger.</typeparam>
    public abstract class BaseServiceContainer<TKey, TValue, TContainerOptions, TContainerLoggerOptions> : IServiceContainer<TKey, TValue, TContainerOptions, TContainerLoggerOptions>
        where TContainerLoggerOptions : class, IServiceContainerLoggerOptions
        where TContainerOptions : class, IServiceContainerOptions<TContainerLoggerOptions>
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
        where TValue : IService
    {
        /// <summary>
        /// Dictionary where the services are stored with their key and value
        /// </summary>
        protected Dictionary<TKey, TValue> _services;

        /// <summary>
        /// Logger, if not implemented is null
        /// </summary>
        protected ILogger? _logger;

        protected BaseServiceContainer(ILogger? logger, IOptionsMonitor<TContainerOptions> containerConfig)
        {
            Config = containerConfig.Get(Name);
            _services = new Dictionary<TKey, TValue>();
            _logger = logger;
            _logger.CheckLoggerImplementation(Config.UseLogger);
        }

        /// <summary>
        /// Gets the configuration options for the service container.
        /// </summary>
        public TContainerOptions Config { get; set; }

        /// <summary>
        /// Gets the level of data access privileges in the service container.
        /// </summary>
        public DataAccesssPrivilegesLevel DataAccesssPrivilegesLevel => DataAccesssPrivilegesLevel.Complete;

        /// <summary>
        /// Gets the data context origin
        /// </summary>
        public DataContextOrigin DataContextOrigin => DataContextOrigin.Memory;

        /// <summary>
        /// Gets the name of the service container
        /// </summary>
        public string Name => GetType().Name;

        /// <summary>
        /// Adds a service to the container.
        /// </summary>
        /// <param name="key">The key to identify the service.</param>
        /// <param name="value">The service to add.</param>
        /// <returns>A task representing the asynchronous operation that returns true if the service was added, false otherwise.</returns>
        public virtual async Task<bool> AddServiceAsync(TKey key, TValue value)
        {
            var actionResult = !await AnyServiceAsync(key) && _services.TryAdd(key, value);
            LogAction(actionResult, ServiceContainerAction.Add);
            return await Task.FromResult(actionResult);
        }

        /// <summary>
        /// Determines if a service with the specified key is present in the container.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>A task representing the asynchronous operation that returns true if the service is present, false otherwise.</returns>

        public virtual async Task<bool> AnyServiceAsync(TKey key)
        {
            var actionResult = _services.ContainsKey(key);
            LogAction(actionResult, ServiceContainerAction.Any);
            return await Task.FromResult(actionResult);
        }

        /// <summary>
        /// Determines if a service is present in the container.
        /// </summary>
        /// <param name="value">The service to check for.</param>
        /// <returns>A task representing the asynchronous operation that returns true if the service is present, false otherwise.</returns>

        public virtual async Task<bool> AnyServiceAsync(TValue value)
        {
            var actionResult = _services.ContainsValue(value);
            LogAction(actionResult, ServiceContainerAction.Any);
            return await Task.FromResult(actionResult);
        }

        /// <summary>
        /// Gets the count of services in the container.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns the number of services.</returns>
        public virtual async Task<int> CountAsync()
        {
            return await Task.FromResult(_services.Count);
        }

        public async ValueTask DisposeAsync()
        {
            await Task.Run(() =>
            {
                GC.SuppressFinalize(this);
            });
        }

        /// <summary>
        /// Gets a service from the container by its key.
        /// </summary>
        /// <param name="key">The key to identify the service.</param>
        /// <returns>A task representing the asynchronous operation that returns the service if it was found, or null if not.</returns>

        public virtual async Task<TValue?> GetServiceAsync(TKey key)
        {
            bool actionResult = false;
            TValue? result = default;
            if (await AnyServiceAsync(key))
            {
                result = _services.GetValueOrDefault(key);
                actionResult = result != null;
            }
            LogAction(actionResult, ServiceContainerAction.Get);

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Logs an action performed on the service container.
        /// </summary>
        /// <param name="actionResult">The actionResult of the action.</param>
        /// <param name="serviceContainerAction">The action performed.</param>
        /// <param name="args">Additional arguments for the action.</param

        public void LogAction(bool actionResult, ServiceContainerAction serviceContainerAction, params object?[] args)
        {
            if (!Config.UseLogger)
                return;

            var message = serviceContainerAction switch
            {
                ServiceContainerAction.Add => actionResult ? Config.LoggerOptions.SetAddServiceSuccessMessage : Config.LoggerOptions.SetAddServiceFailureMessage,
                ServiceContainerAction.Remove => actionResult ? Config.LoggerOptions.SetRemoveServiceSuccessMessage : Config.LoggerOptions.SetRemoveServiceFailureMessage,
                ServiceContainerAction.Any => actionResult ? Config.LoggerOptions.SetAnyServiceSuccessMessage : Config.LoggerOptions.SetAnyServiceFailureMessage,
                ServiceContainerAction.Get => actionResult ? Config.LoggerOptions.SetGetServiceSuccessMessage : Config.LoggerOptions.SetGetServiceFailureMessage,
                _ => null
            };

            if (message != null)
            {
                var logLevel = serviceContainerAction switch
                {
                    ServiceContainerAction.Add => actionResult ? Config.LoggerOptions.SetAddServiceSuccessLogLevel : Config.LoggerOptions.SetAddServiceFailureLogLevel,
                    ServiceContainerAction.Remove => actionResult ? Config.LoggerOptions.SetRemoveServiceSuccessLogLevel : Config.LoggerOptions.SetRemoveServiceFailureLogLevel,
                    ServiceContainerAction.Any => actionResult ? Config.LoggerOptions.SetAnyServiceSuccessLogLevel : Config.LoggerOptions.SetAnyServiceFailureLogLevel,
                    ServiceContainerAction.Get => actionResult ? Config.LoggerOptions.SetGetServiceSuccessLogLevel : Config.LoggerOptions.SetGetServiceFailureLogLevel,
                    _ => LogLevel.None
                };

                _logger?.Log(logLevel, message.Replace(Config.LoggerOptions.ReplaceZoneStringWithServiceName, Name), args);
            }
        }

        /// <summary>
        /// Removes a service from the container by its key.
        /// </summary>
        /// <param name="key">The key to identify the service.</param>
        /// <returns>A task representing the asynchronous operation that returns true if the service was removed, false otherwise.</returns>

        public virtual async Task<bool> RemoveServiceAsync(TKey key)
        {
            bool actionResult = false;
            if (!await AnyServiceAsync(key))
            {
                actionResult = _services.Remove(key);
            }
            LogAction(actionResult, ServiceContainerAction.Remove);
            return await Task.FromResult(actionResult);
        }
    }
}