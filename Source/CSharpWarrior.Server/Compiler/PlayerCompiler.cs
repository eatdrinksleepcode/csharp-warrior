using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
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

        public CompilerResults Compile(string code)
        {
            var results = compiler.CompileAssemblyFromSource(options, code);
            return results;
        }

        public void Dispose()
        {
            compiler.Dispose();
        }
    }
}