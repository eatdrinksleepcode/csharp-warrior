using CSharpWarrior.Compiler;
using FluentAssertions;
using NUnit.Framework;

namespace CSharpWarrior.Web
{
    public class CodeResultResponseTests
    {
        [Test]
        public void HasCompilerErrors()
        {
            var ex = new CodeCompilationException(new [] { "Error 1", "Error 2" });
            var codeResultResponse = CodeResultResponse.CompileError(ex);
            codeResultResponse.Errors.Should().HaveCount(2);
        }
    }
}