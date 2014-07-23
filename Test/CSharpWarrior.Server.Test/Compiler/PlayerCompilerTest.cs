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
        public void ShouldCompileValidCode()
        {
            var compilation = compiler.Compile(TestCode.ValidCode);

            compilation.Errors.Should().BeEmpty();
        }

        [Test]
        public void ShouldNotCompileInvalidCode()
        {
            var compilation = compiler.Compile(TestCode.InvalidCode);

            compilation.Errors.Should().NotBeEmpty();
        }
    }
}

