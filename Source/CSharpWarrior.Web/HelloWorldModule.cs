using System;
using Nancy;

namespace CSharpWarrior.Web
{
	public class HelloWorldModule : NancyModule
	{
		public HelloWorldModule ()
		{
			Get ["/"] = x => View ["HelloWorld"];
		}
	}
}
