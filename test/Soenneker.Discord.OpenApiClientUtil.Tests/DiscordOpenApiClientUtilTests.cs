using Soenneker.Discord.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Discord.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class DiscordOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IDiscordOpenApiClientUtil _openapiclientutil;

    public DiscordOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IDiscordOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
