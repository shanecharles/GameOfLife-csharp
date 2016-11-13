#r "packages/FAKE/tools/FakeLib.dll"

open Fake

let testDir = "./test/"
let appReferences = !! "GameOfLife.sln"

Target "Clean" (fun _ ->
  CleanDir testDir
)

Target "Build" (fun _ ->
  trace "Building the projects..."
  MSBuildDebug testDir "Build" appReferences 
    |> Log "TestBuild-Output: "
)

Target "Test" (fun _ ->
  !! (testDir + "*.Properties.dll") ++ (testDir + "*.Tests.dll")
    |> NUnit (fun p -> 
          {p with 
              DisableShadowCopy = true;
              OutputFile = testDir + "TestResults.xml"})
)
 
"Clean"
  ==> "Build"
  ==> "Test"

RunTargetOrDefault "Test"
