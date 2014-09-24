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

        public const string MissingPlayerClass = @"
                public class NotAPlayer {
                }
                ";

        public const string PlayerClassDoesNotImplementIPlayer = @"
                public class Player {
                }
                ";
    }
}

