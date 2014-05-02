using System;
using System.Diagnostics;
using Nancy.Hosting.Self;

namespace CSharpWarrior.Web
{
	public static class Program
	{
		public static void Main ()
		{
			var hostUri = "http://localhost:1234";
			using (var host = new NancyHost (new Uri (hostUri), new ConsoleBootstrapper ())) {
				host.Start ();
				Process.Start (hostUri);
				Console.WriteLine ("Press any key to exit.");
				Console.ReadKey ();
			}
		}
	}
}
