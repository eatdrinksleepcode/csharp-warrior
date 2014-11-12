using System;
using System.CodeDom.Compiler;
using System.Linq;
using Microsoft.CSharp;
using CSharpWarrior.Domain;
using CSharpWarrior.Compiler;


namespace CSharpWarrior.Compiler
{
    public class PlayerCompiler : IDisposable
    {
        private readonly CSharpCodeProvider compiler = new CSharpCodeProvider();
        private readonly CompilerParameters options = new CompilerParameters();

        public PlayerCompiler()
        {
            options.ReferencedAssemblies.Add(typeof(IPlayer).Assembly.Location);
        }

        public Type Compile(string code)
        {
            var results = compiler.CompileAssemblyFromSource(options, code);

            var errors = results.Errors.Cast<CompilerError>().Where(e => !e.IsWarning).ToArray();

            if(errors.Length > 0) {
                throw new CodeCompilationException(errors);
            }

            var playerType = results.CompiledAssembly.GetType("Player");
            if(null == playerType) {
                throw new CodeCompilationException(new [] { "Code must have a class named 'Player'." });
            } else if(playerType.GetInterface("IPlayer") != typeof(IPlayer)) {
                throw new CodeCompilationException(new [] { string.Format("Class 'Player' must implement interface '{0}'", typeof(IPlayer).FullName) });
            }

            return playerType;
        }

        public void Dispose()
        {
            compiler.Dispose();
        }
    }
}