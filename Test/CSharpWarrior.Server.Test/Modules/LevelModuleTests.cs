using FluentAssertions;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;
using CSharpWarrior.Domain;

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
        public void LevelExists()
        {
            var response = browser.GetJson("/level/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var levelResponse = response.Body.DeserializeJson<LevelResponse>();

            levelResponse.Tiles.Should().BeEquivalentTo(new [] {
                new Tile { HeroIsHere = true },
                new Tile(),
                new Tile { IsExit = true }
            });
            levelResponse.Objective.Should().Be("Be Awesome!");
        }

        [Test]
        public void GoodCode()
        {
            var response = browser.PostJson("/level/1", new { Code = TestCode.ValidCode });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var codeResultResponse = response.Body.DeserializeJson<CodeResultResponse>();
            codeResultResponse.Output.Should().Be("Success!!!");
            codeResultResponse.HasErrors.Should().Be(false);
        }

        [Test]
        public void BadCode()
        {
            var response = browser.PostJson("/level/1", new { Code = TestCode.NonCompilingCode });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var codeResultResponse = response.Body.DeserializeJson<CodeResultResponse>();
            codeResultResponse.Output.Should().Be("Could not compile!!!");
            codeResultResponse.HasErrors.Should().Be(true);
            codeResultResponse.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
