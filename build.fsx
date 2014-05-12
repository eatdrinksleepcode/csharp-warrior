// include Fake lib
#r @"packages/FAKE.2.15.5/tools/Nuget.Core.dll"
#r @"packages/FAKE.2.15.5/tools/FakeLib.dll"
open Fake

Target "BuildApp" (fun _ ->
    !! "Source/CSharpWarrior.Web.Host/CSharpWarrior.Web.Host.csproj"
        |> MSBuildRelease "" "Build"
        |> Log "AppBuild-Output: "
)

// start build
RunTargetOrDefault "BuildApp"