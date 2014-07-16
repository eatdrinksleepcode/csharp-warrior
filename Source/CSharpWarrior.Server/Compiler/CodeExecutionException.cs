using System;
using System.Runtime.Serialization;

namespace CSharpWarrior.Compiler
{
    [Serializable]
    public class CodeExecutionException : Exception
    {
        public CodeExecutionException(string message) : base(message)
        {
        }

        public CodeExecutionException(string message, Exception ex) : base(message, ex)
        {
        }

        protected CodeExecutionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

