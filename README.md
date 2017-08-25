# Example of sharing same feature file between different test projects

Depending on how the team works it might be useful to share same [SpecFlow](http://specflow.org/)  feature files between different test projects. For example same feature file can be used for Unit and Acceptance tests.

## Implementation
The approach used in this example is to use one project as a source and copy new and changed feature files to another project on build.
To accomplish this target project has to have following in `csproj` file.

* Import of SpecFlow targets
```xml
<Import Project="..\packages\SpecFlow.2.2.0\tools\TechTalk.SpecFlow.targets" Condition="Exists('..\packages\SpecFlow.2.2.0\tools\TechTalk.SpecFlow.targets')" />
```
* Targets that copy `feature` files and regenerate code-behind
```xml
  <Target Name="BeforeBuild">
    <CallTarget Condition="'$(NCrunch)' != '1'" Targets="CopyFeatureFilesIfNewer" />
    <CallTarget Condition="'$(NCrunch)' != '1'" Targets="RegenFeatureCodeBehind" />
  </Target>
  <Target Name="CopyFeatureFilesIfNewer">
    <Exec Command="xcopy $(SolutionDir)Tests\Features\*.feature $(SolutionDir)AcceptanceTests\Features\ /d /y /i" />
  </Target>
  <Target Name="RegenFeatureCodeBehind">
    <GenerateAll ShowTrace="$(ShowTrace)" BuildServerMode="$(BuildServerMode)" OverwriteReadOnlyFiles="$(OverwriteReadOnlyFiles)" ProjectPath="$(MSBuildProjectFullPath)" ForceGeneration="$(ForceGeneration)" VerboseOutput="$(VerboseOutput)">
      <Output TaskParameter="GeneratedFiles" ItemName="SpecFlowGeneratedFiles" />
    </GenerateAll>
  </Target>
```
<sub>Note: these targets will not be called if tests are run by NCrunch</sub>