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
        public void SetUp ()
        {
            var bootstrapper = new DefaultNancyBootstrapper ();
            browser = new Browser (bootstrapper);
        }

        [Test]
        public void GoodCode ()
        {
            var response = browser.Post ("/level/1", with => {
                with.AjaxRequest ();
                with.JsonBody (new { Code = TestCode.ValidCode });
                with.Accept ("application/json");
            });

            response.StatusCode.Should ().Be (HttpStatusCode.OK);
            response.Body.DeserializeJson<LevelModule.LevelResponse> ().Result.Should ().Be ("Foobar!");
        }
    }
}
