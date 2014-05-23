using Nancy;
using Nancy.Conventions;

namespace CSharpWarrior.Web
{
    public class WebBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions (Nancy.Conventions.NancyConventions nancyConventions)
        {
            base.ConfigureConventions (nancyConventions);

            nancyConventions.StaticContentsConventions.Add (StaticContentConventionBuilder.AddDirectory ("/Scripts"));
        }
    }
}
