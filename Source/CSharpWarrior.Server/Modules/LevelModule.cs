using Nancy;
using Nancy.ModelBinding;
using CSharpWarrior.Compiler;
using System.CodeDom.Compiler;

namespace CSharpWarrior.Web
{
    public class LevelModule : NancyModule
    {
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

            return compileResult.HasErrors() 
                ? LevelResponse.CompileError(new CompilerErrorCollection()) 
                   : LevelResponse.Success();
        }

    }
}

