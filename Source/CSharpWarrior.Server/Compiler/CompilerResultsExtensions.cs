using Nancy;
using Nancy.ModelBinding;
using CSharpWarrior.Compiler;
using System.CodeDom.Compiler;

namespace CSharpWarrior.Compiler
{
    public static class CompilerResultsExtensions {
        public static bool HasErrors(this CompilerResults source) {
            return source.Errors.Count > 0;
        }
    }
    
}
