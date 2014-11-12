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

        public const string ValidCodeWithWarning = @"
                using CSharpWarrior.Domain;

                public class Player : IPlayer {
                    public WarriorAction Play() {
                        var x = 1;
                        return new WarriorAction();
                    }
                }
                ";

        public const string ValidCodeComplete = @"
                using CSharpWarrior.Domain;

                public class BasePlayer {
                }

                public class Player : BasePlayer, IPlayer {
                    public WarriorAction Play() {
                        PrivateInstanceMethod();
                        PrivateStaticMethod();
                        return new WarriorAction();
                    }

                    private void PrivateInstanceMethod() {
                    }

                    private static void PrivateStaticMethod() {
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

        public const string DangerousCodeConstructor = @"
            using CSharpWarrior.Domain;
            public class Player : IPlayer {
                public WarriorAction Play() {
                    var x = new System.Net.Sockets.TcpClient();
                    return null;
                }
            }
            ";

        public const string DangerousCodeCall = @"
            using CSharpWarrior.Domain;
            public class Player : IPlayer {
                public WarriorAction Play() {
                    System.IO.Directory.EnumerateFiles (@""C:"");
                    return null;
                }
            }
            ";

        public const string DangerousCodeCallVirt = @"
            using CSharpWarrior.Domain;
            public class Player : IPlayer {
                public WarriorAction Play() {
                    new System.Net.Sockets.TcpClient().Connect(""localhost"", 80);
                    return null;
                }
            }
            ";
    
        public const string DangerousCodeInherit = @"
            using CSharpWarrior.Domain;
            public class Player : System.Net.Sockets.TcpClient, IPlayer {
                public WarriorAction Play() {
                    System.IO.Directory.EnumerateFiles (@""C:"");
                    return null;
                }
            }
            ";

    }
}

