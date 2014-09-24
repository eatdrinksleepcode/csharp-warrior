using CSharpWarrior.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace CSharpWarrior.Web
{
    public class CodeResultResponse
    {
        public string Output { get; set; }

        public bool HasErrors { get; set; }

        public List<string> Errors { get; set; }

        public static CodeResultResponse CompileError(CodeCompilationException ex)
        {
            return new CodeResultResponse { 
                Output = "Could not compile!!!", 
                Errors = ex.Errors.ToList(),
                HasErrors = true
            };
        }

        public static CodeResultResponse Success()
        {
            return new CodeResultResponse { 
                Output = "Success!!!", 
                HasErrors = false
            };
        }
    }
    
}
