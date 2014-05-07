using System;
using System.Diagnostics;
using Nancy;
using Nancy.Hosting.Self;

namespace CSharpWarrior.Web
{
	public static class Program
	{
		public static void Main ()
		{
			var hostUri = "http://localhost:1234";
			StaticConfiguration.DisableErrorTraces = false;
			using (var host = new NancyHost (new Uri (hostUri), new ConsoleBootstrapper ())) {
				host.Start ();
				Process.Start (hostUri);
				Console.WriteLine ("Press any key to exit.");
				Console.ReadKey ();
			}
		}
	}
}
