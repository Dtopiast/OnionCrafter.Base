using Microsoft.Extensions.DependencyInjection;
using OnionCrafter.Base.ServiceContainers;
using OnionCrafter.Base.ServiceContainers.Options;

namespace OnionCrafter.Base.DependencyInjection
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/> to register custom service containers.
    /// </summary>
    public static class ServiceContainerExtensionS
    {
        /// <summary>
        /// Adds a service container to the service collection with the specified options and logging options.
        /// </summary>
        /// <typeparam name="TOptions">The type of service container options.</typeparam>
        /// <typeparam name="TOptionsLogging">The type of service container logger options.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="serviceContainerType">The type of the service container.</param>
        /// <param name="implementationServiceContainerType">The type of the implementation of the service container.</param>
        /// <param name="configure">An action to configure the service container options.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddServiceContainer<TOptions, TOptionsLogging>(this IServiceCollection services, Type serviceContainerType, Type implementationServiceContainerType, Action<TOptions> configure)
            where TOptionsLogging : class, IServiceContainerLoggerOptions
            where TOptions : class, IServiceContainerOptions<TOptionsLogging>
        {
            EnsureValidServiceContainerTypes(serviceContainerType, implementationServiceContainerType);
            services.AddOptions<TOptions>(implementationServiceContainerType.Name).Configure(configure);
            services.AddSingleton(serviceContainerType, implementationServiceContainerType);
            return services;
        }

        /// <summary>
        /// Adds a service container to the service collection with the specified options, implementation, and configuration action.
        /// </summary>
        /// <typeparam name="TServiceContainer">The type of service container.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation of the service container.</typeparam>
        /// <typeparam name="TOptions">The type of service container options.</typeparam>
        /// <typeparam name="TOptionsLogging">The type of service container logger options.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="configure">An action to configure the service container options.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddServiceContainer<TServiceContainer, TImplementation, TOptions, TOptionsLogging>(this IServiceCollection services, Action<TOptions> configure)
            where TServiceContainer : BaseServiceContainer
            where TImplementation : class, TServiceContainer
            where TOptionsLogging : class, IServiceContainerLoggerOptions
            where TOptions : class, IServiceContainerOptions<TOptionsLogging>
        {
            services.AddServiceContainer<TOptions, TOptionsLogging>(typeof(TServiceContainer), typeof(TImplementation), configure);
            return services;
        }

        /// <summary>
        /// Adds a service container to the service collection with the default configuration.
        /// </summary>
        /// <typeparam name="TServiceContainer">The type of service container.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation of the service container.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddServiceContainer<TServiceContainer, TImplementation>(this IServiceCollection services)
            where TServiceContainer : BaseServiceContainer
            where TImplementation : class, TServiceContainer
        {
            Action<ServiceContainerOptions<ServiceContainerLoggerOptions>> defaultConfigure = (ServiceContainerOptions<ServiceContainerLoggerOptions> options) =>
            {
                options = new ServiceContainerOptions<ServiceContainerLoggerOptions>();
            };

            services.AddServiceContainer<ServiceContainerOptions<ServiceContainerLoggerOptions>, ServiceContainerLoggerOptions>(typeof(TServiceContainer), typeof(TImplementation), defaultConfigure);
            return services;
        }

        /// <summary>
        /// Ensures that the service container types are valid.
        /// </summary>
        /// <param name="serviceContainerType">The type of the service container.</param>
        /// <param name="implementationServiceContainerType">The type of the implementation of the service container.</param>
        /// <exception cref="ArgumentNullException">Thrown when either <paramref name="serviceContainerType"/> or <paramref name="implementationServiceContainerType"/> is null.</exception>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="serviceContainerType"/> is not a subclass of <see cref="BaseServiceContainer"/> or when <paramref name="implementationServiceContainerType"/> is not a subclass of <paramref name="serviceContainerType"/>.</exception>
        private static void EnsureValidServiceContainerTypes(Type serviceContainerType, Type implementationServiceContainerType)
        {
            if (serviceContainerType is null)
                throw new ArgumentNullException(nameof(serviceContainerType));

            if (implementationServiceContainerType is null)
                throw new ArgumentNullException(nameof(implementationServiceContainerType));

            if (!serviceContainerType.IsSubclassOf(typeof(BaseServiceContainer)))
                throw new InvalidCastException($"Type {serviceContainerType} must be a subclass of {nameof(BaseServiceContainer)}.");

            if (!implementationServiceContainerType.IsSubclassOf(serviceContainerType))
                throw new InvalidCastException($"Type {implementationServiceContainerType} must be a subclass of {serviceContainerType}.");
        }
    }
}