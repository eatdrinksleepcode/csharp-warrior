using System;
using NUnit.Framework;
using CSharpWarrior.Compiler;
using FluentAssertions;
using Mono.Cecil;
using System.IO;

namespace CSharpWarrior.Compiler
{
    public class WhitelistValidatorTests
    {
        [Test]
        public void ValidCode()
        {
            var playerType = new PlayerCompiler().Compile(TestCode.ValidCode);
            var def = AssemblyDefinition.ReadAssembly(playerType.Assembly.Location);
            try {
                new WhitelistValidator().Invoking(x => x.Validate(def)).ShouldNotThrow<CodeExecutionException>();
            } finally {
                File.Delete(playerType.Assembly.Location);
            }
        }

        [Test]
        public void DangerousCodeConstructor()
        {
            var playerType = new PlayerCompiler().Compile(TestCode.DangerousCodeConstructor);
            var def = AssemblyDefinition.ReadAssembly(playerType.Assembly.Location);
            try {
                new WhitelistValidator().Invoking(x => x.Validate(def)).ShouldThrow<CodeExecutionException>();
            } finally {
                File.Delete(playerType.Assembly.Location);
            }
        }

        [Test]
        public void DangerousCodeCall()
        {
            var playerType = new PlayerCompiler().Compile(TestCode.DangerousCodeCall);
            var def = AssemblyDefinition.ReadAssembly(playerType.Assembly.Location);
            try {
                new WhitelistValidator().Invoking(x => x.Validate(def)).ShouldThrow<CodeExecutionException>();
            } finally {
                File.Delete(playerType.Assembly.Location);
            }
        }

        [Test]
        public void DangerousCodeCallVirt()
        {
            var playerType = new PlayerCompiler().Compile(TestCode.DangerousCodeCallVirt);
            var def = AssemblyDefinition.ReadAssembly(playerType.Assembly.Location);
            try {
                new WhitelistValidator().Invoking(x => x.Validate(def)).ShouldThrow<CodeExecutionException>();
            } finally {
                File.Delete(playerType.Assembly.Location);
            }
        }

        [Test]
        public void DangerousCodeInherit()
        {
            var playerType = new PlayerCompiler().Compile(TestCode.DangerousCodeInherit);
            var def = AssemblyDefinition.ReadAssembly(playerType.Assembly.Location);
            try {
                new WhitelistValidator().Invoking(x => x.Validate(def)).ShouldThrow<CodeExecutionException>();
            } finally {
                File.Delete(playerType.Assembly.Location);
            }
        }
    }
}
