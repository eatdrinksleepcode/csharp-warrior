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
            var response = browser.Post("/level/1", with => {
                with.AjaxRequest();
                with.JsonBody(new { Code = TestCode.ValidCode });
                with.Accept("application/json");
            });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var levelResponse = response.Body.DeserializeJson<LevelModule.LevelResponse>();
            levelResponse.Output.Should().Be("Success!!!");
            levelResponse.HasErrors.Should().Be(false);
        }

        [Test]
        public void ShouldSendErrorMessageIfCodeIsInvalid()
        {
            var response = browser.Post("/level/1", with => {
                with.AjaxRequest();
                with.JsonBody(new { Code = TestCode.InvalidCode });
                with.Accept("application/json");
            });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var levelResponse = response.Body.DeserializeJson<LevelModule.LevelResponse>();
            levelResponse.Output.Should().Be("Could not compile!!!");
            levelResponse.HasErrors.Should().Be(true);

        }
    }
}
