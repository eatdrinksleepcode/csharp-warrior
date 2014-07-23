using Nancy;
using Nancy.ModelBinding;
using CSharpWarrior.Compiler;

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
            var compiler = new PlayerCompiler();
            var compileResult = compiler.Compile(code);

            var result = HasCompileErrors(compileResult) ? "Could not compile!!!" : "Success!!!";

            return new LevelResponse { Result = result };

        }

        private static bool HasCompileErrors(System.CodeDom.Compiler.CompilerResults compileResult)
        {
            return compileResult.Errors.Count > 0;
        }

    }
}

