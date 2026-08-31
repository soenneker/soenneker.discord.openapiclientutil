using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Discord.HttpClients.Abstract;
using Soenneker.Discord.OpenApiClientUtil.Abstract;
using Soenneker.Discord.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Discord.OpenApiClientUtil;

///<inheritdoc cref="IDiscordOpenApiClientUtil"/>
public sealed class DiscordOpenApiClientUtil : IDiscordOpenApiClientUtil
{
    private readonly AsyncSingleton<DiscordOpenApiClient> _client;

    public DiscordOpenApiClientUtil(IDiscordOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<DiscordOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new DiscordOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<DiscordOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
