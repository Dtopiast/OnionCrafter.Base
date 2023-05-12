using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnionCrafter.Base.Services;
using System.Diagnostics.CodeAnalysis;

namespace OnionCrafter.Base.DependencyInjection
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddTypedScoped<TService, TImplementation>(this IServiceCollection services)
            where TService : IService
            where TImplementation : class, TService
        {
            services.AddScoped(typeof(TService), typeof(TImplementation));
            return services;
        }

        public static IServiceCollection AddTypedScoped(this IServiceCollection services, Type TService, Type TImplementation)
        {
            if (!CheckServiceTypes(TService, TImplementation))
                throw new InvalidCastException();
            services.AddScoped(TService, TImplementation);
            return services;
        }

        public static IServiceCollection AddTypedScopedWithOptions<TService, TImplementation, TOptions>(this IServiceCollection services, Action<TOptions> configure)
            where TService : IService<TOptions>
            where TImplementation : class, TService
            where TOptions : class, IServiceOptions
        {
            return AddWithOptions(services, typeof(TService), typeof(TImplementation), configure, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddTypedScopedWithOptions<TOptions>(this IServiceCollection services, Type TService, Type TImplementation, Action<TOptions> configure)
            where TOptions : class, IServiceOptions
        {
            return AddWithOptions(services, TService, TImplementation, configure, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddTypedSingleton<TService, TImplementation>(this IServiceCollection services)
                                            where TService : IService
            where TImplementation : class, TService
        {
            services.AddSingleton(typeof(TService), typeof(TImplementation));
            return services;
        }

        public static IServiceCollection AddTypedSingleton(this IServiceCollection services, Type TService, Type TImplementation)
        {
            if (!CheckServiceTypes(TService, TImplementation))
                throw new InvalidCastException();
            services.AddSingleton(TService, TImplementation);
            return services;
        }

        public static IServiceCollection AddTypedSingletonWithOptions<TService, TImplementation, TOptions>(this IServiceCollection services, Action<TOptions> configure)
            where TService : IService<TOptions>
            where TImplementation : class, TService
            where TOptions : class, IServiceOptions
        {
            return AddWithOptions(services, typeof(TService), typeof(TImplementation), configure, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddTypedSingletonWithOptions<TOptions>(this IServiceCollection services, Type TService, Type TImplementation, Action<TOptions> configure)
            where TOptions : class, IServiceOptions
        {
            return AddWithOptions(services, TService, TImplementation, configure, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddTypedTransient<TService, TImplementation>(this IServiceCollection services)
           where TService : IService
           where TImplementation : class, TService
        {
            services.AddTransient(typeof(TService), typeof(TImplementation));
            return services;
        }

        public static IServiceCollection AddTypedTransient(this IServiceCollection services, Type TService, Type TImplementation)
        {
            if (!CheckServiceTypes(TService, TImplementation))
                throw new InvalidCastException();
            services.AddTransient(TService, TImplementation);
            return services;
        }

        public static IServiceCollection AddTypedTransientWithOptions<TService, TImplementation, TOptions>(this IServiceCollection services, Action<TOptions> configure)
            where TService : IService<TOptions>
            where TImplementation : class, TService
            where TOptions : class, IServiceOptions
        {
            return AddWithOptions(services, typeof(TService), typeof(TImplementation), configure, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddTypedTransientWithOptions<TOptions>(this IServiceCollection services, Type TService, Type TImplementation, Action<TOptions> configure)
            where TOptions : class, IServiceOptions
        {
            return AddWithOptions(services, TService, TImplementation, configure, ServiceLifetime.Transient);
        }

        private static IServiceCollection AddWithOptions<TOptions>(IServiceCollection services, Type serviceType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType, Action<TOptions> configure, ServiceLifetime lifetime)
            where TOptions : class, IServiceOptions

        {
            if (!CheckServiceTypes(serviceType, implementationType))
                throw new InvalidCastException();

            services.AddOptions<TOptions>().Configure(configure);
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
            services.Add(descriptor);
            Func<IServiceProvider, TOptions> addOptionDI = (provider) =>
            {
                var options = provider.GetRequiredService<IOptions<TOptions>>();
                return options.Value;
            };
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(addOptionDI);
                    break;

                case ServiceLifetime.Scoped:
                    services.AddScoped(addOptionDI);

                    break;

                case ServiceLifetime.Transient:
                    services.AddTransient(addOptionDI);

                    break;

                default:
                    break;
            }
            return services;
        }

        private static bool CheckServiceTypes(Type serviceType, Type implementationType)
        {
            if (!serviceType.IsGenericType || serviceType.GetGenericTypeDefinition() != typeof(IService<>))
            {
                if (serviceType.IsSubclassOf(typeof(IService)))
                    return implementationType.IsSubclassOf(serviceType);
                else
                    return false;
            }

            var optionsType = serviceType.GetGenericArguments()[0];

            return implementationType.IsSubclassOf(serviceType) && typeof(IServiceOptions).IsAssignableFrom(optionsType);
        }
    }
}