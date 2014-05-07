using System;
using Nancy;

namespace CSharpWarrior.Web
{
	internal class ConsoleBootstrapper : DefaultNancyBootstrapper
	{
		protected override IRootPathProvider RootPathProvider {
			get {
				return new Nancy.Hosting.Self.FileSystemRootPathProvider ();
			}
		}
	}
}
