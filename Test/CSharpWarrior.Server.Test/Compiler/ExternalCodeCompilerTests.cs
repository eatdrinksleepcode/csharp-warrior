using CSharpWarrior.Compiler;
using FluentAssertions;
using NUnit.Framework;

namespace CSharpWarrior.Server
{
    public class ExternalCodeCompilerTests
    {
        public class TestCode
        {
            public const string ValidCode = @"
                    public class Player {
                        public void Foo() {
                        }
                    }
                    ";

            public const string ValidCodeWithWarning = @"
                    public class Player {
                        public void Foo() {
                            var x = 1;
                        }
                    }
                    ";

            public const string NonCompilingCode = @"
                    foobar
                    ";

            public const string CoreRequiringReference = @"
                    using System.Data.SqlClient;
                    public class Player {
                        public void Foo() {
                            SqlConnection reader;
                        }
                    }
                    ";

        }

        private ExternalCodeCompiler compiler;

        [SetUp]
        public void Before()
        {
            compiler = new ExternalCodeCompiler();
        }

        [Test]
        public void ValidCode()
        {
            var compiledAssembly = compiler.Compile(TestCode.ValidCode);
            compiledAssembly.Should().NotBeNull();
        }

        [Test]
        public void ValidCodeWithWarning()
        {
            var compiledAssembly = compiler.Compile(TestCode.ValidCodeWithWarning);
            compiledAssembly.Should().NotBeNull();
        }

        [Test]
        public void NonCompilingCode()
        {
            compiler
                .Invoking(c => c.Compile(TestCode.NonCompilingCode))
                .ShouldThrow<CodeCompilationException>();
        }

        [Test]
        public void CodeRequiringReferenceWithoutReference()
        {
            compiler
                .Invoking(c => c.Compile(TestCode.CoreRequiringReference))
                .ShouldThrow<CodeCompilationException>();
        }

        [Test]
        public void CodeRequiringReferenceWithReference()
        {
            compiler.AddReference("System.Data.dll");
            var compiledAssembly = compiler.Compile(TestCode.CoreRequiringReference);
            compiledAssembly.Should().NotBeNull();
        }

    }
}

