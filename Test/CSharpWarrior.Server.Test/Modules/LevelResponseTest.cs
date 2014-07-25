using System;
using NUnit.Framework;
using System.CodeDom.Compiler;
using FluentAssertions;

namespace CSharpWarrior.Web
{
    public class LevelResponseTest
    {
        [Test]
        public void HasCompilerErrors() {
            var errors = new CompilerErrorCollection() {
                new CompilerError() { ErrorText = "The force is not strong with this code", Line = 42 }
            };
            var levelResponse = LevelResponse.CompileError(errors);
            levelResponse.Errors.Should().BeEquivalentTo("(42) The force is not strong with this code");
        }
    }
}