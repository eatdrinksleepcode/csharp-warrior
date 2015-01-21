using System;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using CSharpWarrior.Compiler;

namespace CSharpWarrior.Server
{
    public class ExternalCodeCompiler : IDisposable
    {
        private readonly CSharpCodeProvider compiler = new CSharpCodeProvider();
        private readonly CompilerParameters options = new CompilerParameters();

        public void AddReference(string location)
        {
            options.ReferencedAssemblies.Add(location);
        }

        public Assembly Compile(string code)
        {
            var results = compiler.CompileAssemblyFromSource(options, code);

            if(!results.IsSuccess()) {
                throw new CodeCompilationException(results.GetErrorsWithoutWarnings());
            }

            return results.CompiledAssembly;
        }

        public void Dispose()
        {
            if(null != compiler) {
                compiler.Dispose();
            }
        }
    }
}

