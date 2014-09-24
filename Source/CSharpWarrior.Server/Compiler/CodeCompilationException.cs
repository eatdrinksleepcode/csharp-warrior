using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Linq;

namespace CSharpWarrior.Compiler
{
    [Serializable]
    public class CodeCompilationException : Exception
    {
        private readonly List<String> errors = new List<string>();

        public CodeCompilationException(CompilerErrorCollection compilationErrors)
            : this(compilationErrors.Cast<CompilerError>().Select(FormatError))
        {
        }

        public CodeCompilationException(IEnumerable<string> compilationErrors)
        {
            errors.AddRange(compilationErrors);
        }

        protected CodeCompilationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IEnumerable<String> Errors {
            get { return errors.AsReadOnly(); }
        }

        private static string FormatError(CompilerError error)
        {
            return string.Format("({0}) {1}", error.Line, error.ErrorText);
        }
    }
}

