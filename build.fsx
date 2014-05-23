// include Fake lib
#r @"packages/FAKE/tools/Nuget.Core.dll"
#r @"packages/FAKE/tools/FakeLib.dll"
open Fake

CreateDir "Build"

Target "NugetRestore" (fun _ ->
    RestorePackages()
)

Target "BuildApp" (fun _ ->
    !! "Source/CSharpWarrior.Web.Host/CSharpWarrior.Web.Host.csproj"
        |> MSBuildRelease "" "Build"
        |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
    !! "Test/**/*.csproj"
        |> MSBuildRelease "" "Build"
        |> Log "TestBuild-Output: "
)

Target "Test" (fun _ ->
    !! "Test/**/bin/Release/*.Test.dll"
        |> NUnit (fun p -> { p with OutputFile = "Build/TestResults.xml" })
)

Target "NpmRestore" (fun _ ->
    let exitCode = Shell.Exec("npm", "install")
    trace(exitCode.ToString())
    if exitCode <> 0 then failwithf "npm install failed: %i" exitCode
)

Target "WatchTypeScript" (fun _ ->
    let exitCode = Shell.Exec("grunt", "watch")
    trace(exitCode.ToString())
    if exitCode <> 0 then failwithf "grunt watch failed: %i" exitCode
)

"NugetRestore"
    ==> "BuildApp"
    <=> "BuildTest"
    ==> "Test"

"NpmRestore"
    ==> "WatchTypeScript"

RunTargetOrDefault "Test"