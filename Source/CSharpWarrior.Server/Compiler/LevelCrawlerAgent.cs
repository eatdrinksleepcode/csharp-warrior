using System;
using System.Linq;
using CSharpWarrior.Domain;

namespace CSharpWarrior.Compiler
{
    public class LevelCrawlerAgent : SandboxAgent
    {
        public const string IncorrectCodeMessage =
            "Code must have one and only one class that implements the 'IPlayer' interface";

        public override object Execute(IAssembly loadedAssembly, object data)
        {
            var player = (from type in loadedAssembly.GetTypes()
                                   where typeof(IPlayer).IsAssignableFrom(type)
                                   select (IPlayer)Activator.CreateInstance(type)
                         ).ToArray();
            if(player.Length != 1) {
                throw new CodeExecutionException(IncorrectCodeMessage);
            }

            return true;
        }
    }
}

