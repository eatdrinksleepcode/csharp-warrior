using FluentAssertions;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;

namespace CSharpWarrior.Web
{
    public static class BrowserExtensions {
        public static BrowserResponse PostJson<T>(this Browser browser, string url, T json) {
            return browser.Post(url, with => {
                    with.AjaxRequest();
                    with.JsonBody(json);
                    with.Accept("application/json");
            });
        }
    }
    
}
