using System.CodeDom.Compiler;
using FluentAssertions;
using NUnit.Framework;

namespace CSharpWarrior.Compiler
{
    public class CodeCompilationExceptionTests
    {
        [Test]
        public void FormatCompilerErrors()
        {
            var errors = new [] {
                new CompilerError { ErrorText = "The force is not strong with this code", Line = 42 }
            };
            var ex = new CodeCompilationException(errors);
            ex.Errors.ShouldAllBeEquivalentTo(new [] { "(42) The force is not strong with this code" });
        }
    }
}
