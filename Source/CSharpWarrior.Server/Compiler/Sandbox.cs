using System;
using System.Security;
using System.Security.Permissions;

namespace CSharpWarrior.Compiler
{
    public class Sandbox : IDisposable
    {
        private AppDomain sandboxAppDomain;
        private readonly PlayerCompiler compiler = new PlayerCompiler();

        public object ExecuteAssembly<TAgent, TData>(string pathToAssembly, TData data) where TAgent: SandboxAgent
        {
            var sandboxAgent = CreateExecutor<TAgent>(pathToAssembly);
            return sandboxAgent.LoadAndExecute(pathToAssembly, data);
        }

        private TAgent CreateExecutor<TAgent>(string pathToAssembly) where TAgent: SandboxAgent
        {
            return (TAgent)Activator.CreateInstanceFrom(sandboxAppDomain ?? (sandboxAppDomain = CreateSandbox(pathToAssembly, typeof(TAgent))), typeof(TAgent).Assembly.ManifestModule.FullyQualifiedName,
                typeof(TAgent).FullName).Unwrap(); 
        }

        private AppDomain CreateSandbox(string pathToAssembly, Type agentType)
        {
            var perms = new PermissionSet(PermissionState.Unrestricted);

            return AppDomain.CreateDomain("Sandbox", null, AppDomain.CurrentDomain.SetupInformation, perms);
        }

        public void Dispose()
        {
            if(null != sandboxAppDomain) {
                AppDomain.Unload(sandboxAppDomain);
                sandboxAppDomain = null;
            }
            compiler.Dispose();
        }
    }
}
