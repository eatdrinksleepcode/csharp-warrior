using FluentAssertions;
using Moq;
using NUnit.Framework;
using CSharpWarrior.Domain;

namespace CSharpWarrior.Compiler
{
    public class LevelCrawlerAgentTest
    {
        public class ValidPlayer : IPlayer
        {
            public WarriorAction Play()
            {
                return new WarriorAction();
            }
        }

        private LevelCrawlerAgent agent;

        [SetUp]
        public void Before()
        {
            agent = new LevelCrawlerAgent();
        }

        [Test]
        public void ShouldFailToRunWithoutValidPlayer()
        {
            var assembly = new Mock<IAssembly>();
            assembly.Setup(a => a.GetTypes()).Returns(new[] { typeof(string) });

            agent.Invoking(a => a.Execute(assembly.Object, null))
                .ShouldThrow<CodeExecutionException>()
                .WithMessage(LevelCrawlerAgent.IncorrectCodeMessage);
        }

        [Test]
        public void ShouldFailToRunWithMoreThanOneValidPlayer()
        {
            var assembly = new Mock<IAssembly>();
            assembly.Setup(a => a.GetTypes()).Returns(new[] { typeof(ValidPlayer), typeof(ValidPlayer) });

            agent.Invoking(a => a.Execute(assembly.Object, null))
                .ShouldThrow<CodeExecutionException>()
                .WithMessage(LevelCrawlerAgent.IncorrectCodeMessage);
        }

        [Test]
        public void ShouldRunWithValidPlayer()
        {
            var assembly = new Mock<IAssembly>();
            assembly.Setup(a => a.GetTypes()).Returns(new[] { typeof(ValidPlayer) });

            agent.Invoking(a => a.Execute(assembly.Object, null))
                .ShouldNotThrow();
        }
    }
}
