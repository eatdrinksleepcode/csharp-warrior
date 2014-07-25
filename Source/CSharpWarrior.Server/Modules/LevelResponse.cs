using Nancy;
using Nancy.ModelBinding;
using CSharpWarrior.Compiler;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace CSharpWarrior.Web
{
    public class LevelResponse
    {
        public string Output { get; set; }
        public bool HasErrors { get; set; }
        public List<string> Errors { get; set; }

        public static LevelResponse CompileError(CompilerErrorCollection errors) {
            return new LevelResponse { 
                Output = "Could not compile!!!", 
                Errors = errors.Cast<CompilerError>()
                               .Select(FormatError)
                               .ToList(),
                HasErrors = true
            };
        }

        private static string FormatError(CompilerError error)
        {
            return string.Format("({0}) {1}", error.Line, error.ErrorText);
        }

        public static LevelResponse Success() {
            return new LevelResponse { 
                Output = "Success!!!", 
                HasErrors = false
            };
        }
    }
    
}
