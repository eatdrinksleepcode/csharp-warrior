using Nancy;
using Nancy.ModelBinding;
using CSharpWarrior.Compiler;

namespace CSharpWarrior.Web
{
    public class LevelModule : NancyModule
    {
        public class LevelResponse
        {
            public string Output { get; set; }
            public bool HasErrors { get; set; }

            public static LevelResponse CompileError() {
                return new LevelResponse { Output = "Could not compile!!!", HasErrors = true };
            }

            public static LevelResponse Success() {
                return new LevelResponse { Output = "Success!!!", HasErrors = false };
            }
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
            var compiler = new PlayerCompiler();
            var compileResult = compiler.Compile(code);

            if(compileResult.Errors.Count > 0) {
                return LevelResponse.CompileError();
            } else {
                return LevelResponse.Success();
            }

        }

    }
}

