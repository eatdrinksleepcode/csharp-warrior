using FluentAssertions;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;

namespace CSharpWarrior.Web
{
    public class LevelModuleTests
    {
        Browser browser;

        [SetUp]
        public void SetUp()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            browser = new Browser(bootstrapper);
        }

        [Test]
        public void GoodCode()
        {
            var response = browser.PostJson("/level/1", new { Code = TestCode.ValidCode });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var levelResponse = response.Body.DeserializeJson<LevelResponse>();
            levelResponse.Output.Should().Be("Success!!!");
            levelResponse.HasErrors.Should().Be(false);
        }

        [Test]
        public void BadCode()
        {
            var response = browser.PostJson("/level/1", new { Code = TestCode.InvalidCode });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var levelResponse = response.Body.DeserializeJson<LevelResponse>();
            levelResponse.Output.Should().Be("Could not compile!!!");
            levelResponse.HasErrors.Should().Be(true);
            levelResponse.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
