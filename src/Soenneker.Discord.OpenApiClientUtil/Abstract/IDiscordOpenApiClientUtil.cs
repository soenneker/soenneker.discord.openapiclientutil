using Soenneker.Discord.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Discord.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IDiscordOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<DiscordOpenApiClient> Get(CancellationToken cancellationToken = default);
}
