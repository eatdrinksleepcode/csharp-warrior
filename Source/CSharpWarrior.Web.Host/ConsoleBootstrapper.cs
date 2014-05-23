using System;
using Nancy;

namespace CSharpWarrior.Web
{
    internal class ConsoleBootstrapper : WebBootstrapper
    {
        protected override IRootPathProvider RootPathProvider {
            get {
                return new Nancy.Hosting.Self.FileSystemRootPathProvider ();
            }
        }
    }
}
