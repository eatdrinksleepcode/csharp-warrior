using System;
using CSharpWarrior.Compiler;
using CSharpWarrior.Domain;
using CSharpWarrior.Server;


namespace CSharpWarrior.Compiler
{
    public class PlayerCompiler : IDisposable
    {
        private readonly ExternalCodeCompiler compiler = new ExternalCodeCompiler();

        public PlayerCompiler()
        {
            compiler.AddReference(typeof(IPlayer).Assembly.Location);
        }

        public Type Compile(string code)
        {
            var compiledAssembly = compiler.Compile(code);

            var playerType = compiledAssembly.GetType("Player");
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