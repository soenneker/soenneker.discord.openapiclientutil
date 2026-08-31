[![](https://img.shields.io/nuget/v/soenneker.discord.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.discord.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.discord.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.discord.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.discord.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.discord.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.discord.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.discord.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Discord.OpenApiClientUtil

Provides a lazily created, cached Discord API client backed by `Soenneker.Discord.HttpClients`.

## Installation

```bash
dotnet add package Soenneker.Discord.OpenApiClientUtil
```

## Configuration and registration

```json
{
  "Discord": {
    "ApiKey": "your-bot-token"
  }
}
```

```csharp
using Soenneker.Discord.OpenApiClientUtil.Registrars;

services.AddDiscordOpenApiClientUtilAsScoped();
```

The HTTP provider sends `Authorization: Bot <ApiKey>`. Set `Discord:AuthHeaderValueTemplate` to `Bearer {token}` when the configured credential is an OAuth access token.

## Usage

```csharp
using Soenneker.Discord.OpenApiClientUtil.Abstract;

public sealed class DiscordUserReader(IDiscordOpenApiClientUtil clients)
{
    public async Task Read(CancellationToken cancellationToken)
    {
        var client = await clients.Get(cancellationToken);
        var currentUser = await client.Users.Me.GetAsync(cancellationToken: cancellationToken);
    }
}
```

Use `AddDiscordOpenApiClientUtilAsSingleton()` when the application should share one generated client. Both registrations use a singleton HTTP provider, so disposing a scoped utility does not remove the shared transport; the provider owns and disposes it at application shutdown.
