Require<Bau>()

.Task("default").DependsOn("unit", "component")

.Task("logs").Do(() => CreateDirectory("artifacts/logs"))

.Exec("clean").DependsOn("logs").Do(exec => exec
    .Run("xbuild")
    .With("CSharpWarrior.sln", "/target:Clean", "/property:Configuration=Release", "/verbosity:normal", "/nologo"))

.Exec("restore").Do(exec => exec
    .Run("mono")
    .With("scriptcs_packages/NuGet.CommandLine.2.8.3/tools/NuGet.exe", "restore", "CSharpWarrior.sln"))

.Exec("build").DependsOn("clean", "restore", "logs").Do(exec => exec
    .Run("xbuild")
    .With("CSharpWarrior.sln", "/target:Build", "/property:Configuration=Release", "/verbosity:normal", "/nologo"))

.Task("tests").Do(() => CreateDirectory("artifacts/tests"))

.Xunit("unit").DependsOn("build", "tests").Do(xunit => xunit
    .Use("./scriptcs_packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe")
    .Run("./src/test/Bau.Test.Unit/bin/Release/Bau.Test.Unit.dll", "./src/test/Bau.Xunit.Test.Unit/bin/Release/Bau.Xunit.Test.Unit.dll")
    .Html().Xml())

.Xunit("component").DependsOn("build", "tests").Do(xunit => xunit
    .Use("./scriptcs_packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe")
    .Run("./src/test/Bau.Test.Component/bin/Release/Bau.Test.Component.dll")
    .Html().Xml())

.Run();

void CreateDirectory(string name)
{
    if (!Directory.Exists(name))
    {
        Directory.CreateDirectory(name);
        System.Threading.Thread.Sleep(100); // HACK (adamralph): wait for the directory to be created
    }
}
