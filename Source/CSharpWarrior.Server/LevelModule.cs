using Nancy;

namespace CSharpWarrior.Web
{
    public class LevelModule : NancyModule
    {
        public class LevelResponse
        {
            public string Result { get; set; }
        }

        public LevelModule ()
        {
            Post ["/level/{currentLevel}"] = args => new LevelResponse { Result = "Foobar!" };
        }
    }
}

