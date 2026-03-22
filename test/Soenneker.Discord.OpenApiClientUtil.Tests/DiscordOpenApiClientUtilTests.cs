using Soenneker.Discord.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Discord.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class DiscordOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IDiscordOpenApiClientUtil _openapiclientutil;

    public DiscordOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IDiscordOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
