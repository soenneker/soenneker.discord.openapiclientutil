using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Discord.HttpClients.Registrars;
using Soenneker.Discord.OpenApiClientUtil.Abstract;

namespace Soenneker.Discord.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class DiscordOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="DiscordOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDiscordOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDiscordOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IDiscordOpenApiClientUtil, DiscordOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="DiscordOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDiscordOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddDiscordOpenApiHttpClientAsSingleton()
                .TryAddScoped<IDiscordOpenApiClientUtil, DiscordOpenApiClientUtil>();

        return services;
    }
}
