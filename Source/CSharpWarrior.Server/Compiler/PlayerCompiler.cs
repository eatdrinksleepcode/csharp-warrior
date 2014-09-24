using System;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using CSharpWarrior.Domain;


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

            if(results.HasErrors()) {
                throw new CodeCompilationException(results.Errors);
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