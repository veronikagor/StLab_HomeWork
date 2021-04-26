using Xunit;

namespace Lessons10_REST_API.Base
{
    [CollectionDefinition("TestRail collection")]
    public class TestRailCollection: ICollectionFixture<TestRailFixture>
    {
    }
}