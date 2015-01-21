using Nancy;
using Nancy.ModelBinding;
using CSharpWarrior.Compiler;
using System.CodeDom.Compiler;
using System.Linq;

namespace CSharpWarrior.Compiler
{
    public static class CompilerResultsExtensions
    {
        public static bool IsSuccess(this CompilerResults source)
        {
            return null != source.CompiledAssembly;
        }


        public static CompilerError[] GetErrorsWithoutWarnings(this CompilerResults source)
        {
            return source.Errors.Cast<CompilerError>().Where(e => !e.IsWarning).ToArray();
        }
    }
    
}
