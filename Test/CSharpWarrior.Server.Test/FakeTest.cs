using System;
using FluentAssertions;
using NUnit.Framework;

namespace CSharpWarrior.Domain.Test
{
    public class FakeTest
    {
        [Test ()]
        public void WillItPass ()
        {
            true.Should ().Be (true);
        }
    }
}
