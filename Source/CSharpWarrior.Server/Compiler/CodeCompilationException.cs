using System;
using System.Runtime.Serialization;

namespace CSharpWarrior.Compiler
{
    [Serializable]
    public class CodeCompilationException : Exception
    {
        public CodeCompilationException(string message) : base(message)
        {

        }

        protected CodeCompilationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

