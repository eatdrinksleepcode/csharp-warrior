using System;
using NUnit.Framework;
using System.CodeDom.Compiler;
using FluentAssertions;

namespace CSharpWarrior.Web
{
    public class CodeResultResponseTests
    {
        [Test]
        public void HasCompilerErrors() {
            var errors = new CompilerErrorCollection() {
                new CompilerError() { ErrorText = "The force is not strong with this code", Line = 42 }
            };
            var codeResultResponse = CodeResultResponse.CompileError(errors);
            codeResultResponse.Errors.Should().BeEquivalentTo("(42) The force is not strong with this code");
        }
    }
}