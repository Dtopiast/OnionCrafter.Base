using OnionCrafter.Base.ServiceContainers.Options;
using OnionCrafter.Base.Services;

namespace OnionCrafter.Base.ServiceContainers
{
    /// <summary>
    /// Enumeration of possible actions to perform in a service container.
    /// </summary>
    public enum ServiceContainerAction
    {
        None = 0,
        Add,
        Remove,
        Any,
        Get
    }

    /// <summary>
    /// Interface for a service container that stores and manages services based on a key and value.
    /// </summary>
    /// <typeparam name="TKey">The type of the key to identify the services.</typeparam>
    /// <typeparam name="TValue">The type of the services to store.</typeparam>
    /// <typeparam name="TContainerOptions">The type of options for the service container.</typeparam>
    /// <typeparam name="TContainerLoggerOptions">The type of options for the service container logger.</typeparam>
    public interface IServiceContainer<TKey, TValue, TContainerOptions, TContainerLoggerOptions> : BaseServiceContainer
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
        where TValue : IService
        where TContainerLoggerOptions : class, IServiceContainerLoggerOptions
        where TContainerOptions : IServiceContainerOptions<TContainerLoggerOptions>
    {
        /// <summary>
        /// Gets the configuration options for the service container.
        /// </summary>
        public TContainerOptions Config { get; }

        /// <summary>
        /// Adds a service to the container.
        /// </summary>
        /// <param name="key">The key to identify the service.</param>
        /// <param name="value">The service to add.</param>
        /// <returns>A task representing the asynchronous operation that returns true if the service was added, false otherwise.</returns>
        public Task<bool> AddServiceAsync(TKey key, TValue value);

        /// <summary>
        /// Determines if a service with the specified key is present in the container.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>A task representing the asynchronous operation that returns true if the service is present, false otherwise.</returns>
        public Task<bool> AnyServiceAsync(TKey key);

        /// <summary>
        /// Determines if a service is present in the container.
        /// </summary>
        /// <param name="value">The service to check for.</param>
        /// <returns>A task representing the asynchronous operation that returns true if the service is present, false otherwise.</returns>
        public Task<bool> AnyServiceAsync(TValue value);

        /// <summary>
        /// Gets the count of services in the container.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns the number of services.</returns>
        public Task<int> CountAsync();

        /// <summary>
        /// Gets a service from the container by its key.
        /// </summary>
        /// <param name="key">The key to identify the service.</param>
        /// <returns>A task representing the asynchronous operation that returns the service if it was found, or null if not.</returns>
        public Task<TValue?> GetServiceAsync(TKey key);

        /// <summary>
        /// Logs an action performed on the service container.
        /// </summary>
        /// <param name="actionResult">The result of the action.</param>
        /// <param name="serviceContainerAction">The action performed.</param>
        /// <param name="args">Additional arguments for the action.</param
        public abstract void LogAction(bool actionResult, ServiceContainerAction serviceContainerAction, params object?[] args);

        /// <summary>
        /// Removes a service from the container by its key.
        /// </summary>
        /// <param name="key">The key to identify the service.</param>
        /// <returns>A task representing the asynchronous operation that returns true if the service was removed, false otherwise.</returns>
        public Task<bool> RemoveServiceAsync(TKey key);
    }
}