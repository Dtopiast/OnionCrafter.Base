using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnionCrafter.Base.Services;
using OnionCrafter.Base.Services.Options;
using System.Diagnostics.CodeAnalysis;

namespace OnionCrafter.Base.DependencyInjection
{
    public static class ServiceExtension
    {
        /// <summary> Adds a typed scoped service of type <typeparamref name="TService"/> with an
        /// implementation of type <typeparamref name="TImplementation"/> to the <see
        /// cref="IServiceCollection"/>. <typeparam name="TService">The type of the service to
        /// add.</typeparam> <typeparam name="TImplementation">The type of the implementation to
        /// use.</typeparam> <param name="services">The <see cref="IServiceCollection"/> to add the
        /// service to.</param> <returns>The <see cref="IServiceCollection"/> so that additional
        /// calls can be chained.</returns>
        public static IServiceCollection AddTypedScoped<TService, TImplementation>(this IServiceCollection services)
                   where TService : IService
                   where TImplementation : class, TService
        {
            services.AddTypedScoped(typeof(TService), typeof(TImplementation));
            return services;
        }

        /// <summary>
        /// Adds a typed scoped service of the type specified in <typeparamref name="TService"/>
        /// with an implementation of the type specified in <typeparamref name="TImplementation"/>
        /// to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="TService">The type of the service to register.</param>
        /// <param name="TImplementation">The type of the implementation to use.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTypedScoped(this IServiceCollection services, Type TService, Type TImplementation)
        {
            EnsureValidServiceTypes(TService, TImplementation);
            services.AddScoped(TService, TImplementation);
            return services;
        }

        /// <summary>
        /// Adds a typed scoped service of the type specified in <typeparamref name="TService"/>
        /// with an implementation of the type specified in <typeparamref name="TImplementation"/>
        /// to the specified <see cref="IServiceCollection"/> with <typeparamref name="TOptions"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <typeparam name="TOptions">The type of the options to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="configure">A callback to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>

        public static IServiceCollection AddTypedScoped<TService, TImplementation, TOptions>(this IServiceCollection services, Action<TOptions> configure)
            where TService : IService<TOptions>
            where TImplementation : class, TService
            where TOptions : class, IServiceOptions
        {
            return AddTypedService(services, typeof(TService), typeof(TImplementation), configure, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Adds a typed scoped service of the type specified in <typeparamref name="TService"/>
        /// with an implementation of the type specified in <typeparamref name="TImplementation"/>
        /// to the specified <see cref="IServiceCollection"/> with <typeparamref name="TOptions"/>.
        /// </summary>
        /// <typeparam name="TOptions">The type of the options.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="TService">The type of the service to register.</param>
        /// <param name="TImplementation">The type of the implementation to use.</param>
        /// <param name="configure">A callback to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTypedScoped<TOptions>(this IServiceCollection services, Type TService, Type TImplementation, Action<TOptions> configure)
            where TOptions : class, IServiceOptions
        {
            return AddTypedService(services, TService, TImplementation, configure, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Adds a typed service of the type specified in <paramref name="serviceType"/> with a
        /// factory specified in <paramref name="implementationType"/> to the <see
        /// cref="IServiceCollection"/> with the given <paramref name="lifetime"/> and <paramref name="configure"/>.
        /// </summary>
        /// <typeparam name="TOptions">The type of the options to be configured.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to be added.</param>
        /// <param name="implementationType">The type of the implementation to be used.</param>
        /// <param name="configure">A delegate to configure the <typeparamref name="TOptions"/>.</param>
        /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service to be added.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTypedService<TOptions>(IServiceCollection services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType, Action<TOptions> configure, ServiceLifetime lifetime)
            where TOptions : class, IServiceOptions
        {
            EnsureValidServiceTypes(serviceType, implementationType);

            services.AddOptions<TOptions>().Configure(configure);
            var descriptorService = new ServiceDescriptor(serviceType, implementationType, lifetime);
            services.Add(descriptorService);
            return services;
        }

        /// <summary>
        /// Adds a typed singleton service of type <typeparamref name="TService"/> with an
        /// implementation of type <typeparamref name="TImplementation"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTypedSingleton<TService, TImplementation>(this IServiceCollection services)
                                                    where TService : IService
            where TImplementation : class, TService
        {
            services.AddSingleton(typeof(TService), typeof(TImplementation));
            return services;
        }

        /// <summary>
        /// Adds a typed singleton service of the type specified in <typeparamref name="TService"/>
        /// with an implementation of the type specified in <typeparamref name="TImplementation"/>
        /// to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="TService">The type of the service to register.</param>
        /// <param name="TImplementation">The type of the implementation to use.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTypedSingleton(this IServiceCollection services, Type TService, Type TImplementation)
        {
            EnsureValidServiceTypes(TService, TImplementation);

            services.AddTypedSingleton(TService, TImplementation);
            return services;
        }

        /// <summary>
        /// Adds a typed singleton service of type <typeparamref name="TService"/> with an
        /// implementation of type <typeparamref name="TImplementation"/> to the <see
        /// cref="IServiceCollection"/> with <typeparamref name="TOptions"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <typeparam name="TOptions">The type of the options to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="configure">A configuration action to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddTypedSingleton<TService, TImplementation, TOptions>(this IServiceCollection services, Action<TOptions> configure)
            where TService : IService<TOptions>
            where TImplementation : class, TService
            where TOptions : class, IServiceOptions
        {
            return AddTypedService(services, typeof(TService), typeof(TImplementation), configure, ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds a typed singleton service of type <typeparamref name="TService"/> with an
        /// implementation of type <typeparamref name="TImplementation"/> to the <see
        /// cref="IServiceCollection"/> with <typeparamref name="TOptions"/>.
        /// </summary>
        /// <typeparam name="TOptions">The type of the options.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="TService">The type of the service to register.</param>
        /// <param name="TImplementation">The type of the implementation to use.</param>
        /// <param name="configure">A configuration action to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddTypedSingleton<TOptions>(this IServiceCollection services, Type TService, Type TImplementation, Action<TOptions> configure)
            where TOptions : class, IServiceOptions
        {
            return AddTypedService(services, TService, TImplementation, configure, ServiceLifetime.Singleton);
        }

        /// <summary>
        /// Adds a typed transient service of type <typeparamref name="TService"/> with an
        /// implementation of type <typeparamref name="TImplementation"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTypedTransient<TService, TImplementation>(this IServiceCollection services)
           where TService : IService
           where TImplementation : class, TService
        {
            services.AddTypedTransient(typeof(TService), typeof(TImplementation));
            return services;
        }

        /// <summary>
        /// Adds a typed transient service of type <typeparamref name="TService"/> with an
        /// implementation of type <typeparamref name="TImplementation"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="TService">The type of the service to register.</param>
        /// <param name="TImplementation">The type of the implementation to use.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTypedTransient(this IServiceCollection services, Type TService, Type TImplementation)
        {
            EnsureValidServiceTypes(TService, TImplementation);
            services.AddTransient(TService, TImplementation);
            return services;
        }

        /// <summary>
        /// Adds a typed transient service of type <typeparamref name="TService"/> with an
        /// implementation of type <typeparamref name="TImplementation"/> to the <see
        /// cref="IServiceCollection"/> with <typeparamref name="TOptions"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <typeparam name="TOptions">The type of the options to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="configure">A configuration action to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTypedTransient<TService, TImplementation, TOptions>(this IServiceCollection services, Action<TOptions> configure)
            where TService : IService<TOptions>
            where TImplementation : class, TService
            where TOptions : class, IServiceOptions
        {
            return AddTypedService(services, typeof(TService), typeof(TImplementation), configure, ServiceLifetime.Transient);
        }

        /// <summary>
        /// Adds a typed transient service of type <typeparamref name="TService"/> with an
        /// implementation of type <typeparamref name="TImplementation"/> to the <see
        /// cref="IServiceCollection"/> with <typeparamref name="TOptions"/>.
        /// </summary>
        /// <typeparam name="TOptions">The type of the options.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="TService">The type of the service to register.</param>
        /// <param name="TImplementation">The type of the implementation to use.</param>
        /// <param name="configure">A configuration action to configure the <typeparamref name="TOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddTypedTransient<TOptions>(this IServiceCollection services, Type TService, Type TImplementation, Action<TOptions> configure)
            where TOptions : class, IServiceOptions
        {
            return AddTypedService(services, TService, TImplementation, configure, ServiceLifetime.Transient);
        }

        /// <summary>
        /// Ensures that the service types are valid.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <param name="implementationType">The type of the implementation of the service.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when either <paramref name="serviceType"/> or <paramref
        /// name="implementationType"/> is null.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// Thrown when <paramref name="serviceType"/> is not a subclass of <see
        /// cref="IBaseService"/> or when <paramref name="implementationType"/> is not a subclass of
        /// <paramref name="serviceType"/>.
        /// </exception>
        private static void EnsureValidServiceTypes(Type serviceType, Type implementationType)
        {
            if (serviceType is null)
                throw new ArgumentNullException(nameof(serviceType));

            if (implementationType is null)
                throw new ArgumentNullException(nameof(implementationType));

            if (!serviceType.IsSubclassOf(typeof(IBaseService)))
                throw new InvalidCastException($"Type {serviceType} must be a subclass of {nameof(IBaseService)}.");

            if (!implementationType.IsSubclassOf(serviceType))
                throw new InvalidCastException($"Type {implementationType} must be a subclass of {serviceType}.");
        }
    }
}