using System;

namespace CSharpWarrior
{
    public static class TestCode
    {
        public const string ValidCode = @"
                using CSharpWarrior.Domain;
                public class Player : IPlayer {
                    public WarriorAction Play() {
                        return new WarriorAction();
                    }
                }
                ";

        public const string IncompleteCode = @"
                public class Player {
                }
                ";

        public const string NonCompilingCode = @"
                foobar
                ";

        public const string InvalidCode = @"
                public class NotAPlayer {
                }
                ";
    }
}

