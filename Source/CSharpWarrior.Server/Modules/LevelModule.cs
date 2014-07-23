using Nancy;
using Nancy.ModelBinding;

namespace CSharpWarrior.Web
{
    public class LevelModule : NancyModule
    {
        public class LevelResponse
        {
            public string Result { get; set; }
        }

        private class LevelCode
        {
            public string Code { get; set; }
        }

        public LevelModule()
        {
            Post["/level/{currentLevel}"] = args => {
                var code = this.Bind<LevelCode>().Code;
                return PostCodeToLevel(code);
            };
        }

        public LevelResponse PostCodeToLevel(string code)
        {
            return new LevelResponse { Result = "Foobar!" };
        }
    }
}

