using FluentAssertions;
using NUnit.Framework;
using System;

namespace CSharpWarrior.Compiler
{
    public class PlayerCompilerTest
    {
        private PlayerCompiler compiler;

        [SetUp]
        public void Before()
        {
            compiler = new PlayerCompiler();
        }

        [Test]
        public void ValidCode()
        {
            var playerType = compiler.Compile(TestCode.ValidCode);

            playerType.Name.Should().Be("Player");
        }

        [Test]
        public void NonCompilingCode()
        {
            Action act = () => compiler.Compile(TestCode.NonCompilingCode);

            act.ShouldThrow<CodeCompilationException>();
        }

        [Test]
        public void InvalidCode()
        {
            Action act = () => compiler.Compile(TestCode.InvalidCode);

            act.ShouldThrow<CodeCompilationException>();
        }
    }
}
