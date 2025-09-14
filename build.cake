// Using global tools - install with: dotnet tool install --global dotnet-reportgenerator-globaltool

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

// Build Configuration
var solutionFile = "./PaySafe.sln";
var testProjects = "./src/Apps/tests/**/*.csproj";
var artifactsDir = "./artifacts";
var testResultsDir = $"{artifactsDir}/test-results";
var coverageResultsDir = $"{artifactsDir}/coverage";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(artifactsDir);
    
    var binDirectories = GetDirectories("./src/**/bin");
    var objDirectories = GetDirectories("./src/**/obj");
    
    CleanDirectories(binDirectories);
    CleanDirectories(objDirectories);
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetRestore(solutionFile);
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetBuild(solutionFile, new DotNetBuildSettings
    {
        Configuration = configuration,
        NoRestore = true
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    var projects = GetFiles(testProjects);
    
    foreach(var project in projects)
    {
        DotNetTest(project.FullPath, new DotNetTestSettings
        {
            Configuration = configuration,
            NoRestore = true,
            NoBuild = true,
            Verbosity = DotNetVerbosity.Normal,
            Collectors = new[] { "XPlat Code Coverage" },
            ResultsDirectory = testResultsDir,
            Loggers = new[] { "trx" },
            Settings = "./coverage.runsettings"
        });
    }
});

Task("TestReport")
    .IsDependentOn("Test")
    .Does(() =>
{
    var coverageFiles = GetFiles($"{testResultsDir}/**/*.cobertura.xml");
    
    if (coverageFiles.Any())
    {
        var coverageFilesString = string.Join(";", coverageFiles.Select(f => f.FullPath));
        var classFilters = "+PaySafe.Domain.*.Entities.*;+PaySafe.Domain.*.Services.*";
        var reportGeneratorArgs = $"-reports:{coverageFilesString} -targetdir:{coverageResultsDir} -reporttypes:Html;Cobertura;TextSummary -classfilters:{classFilters}";
        
        StartProcess("reportgenerator", new ProcessSettings
        {
            Arguments = reportGeneratorArgs
        });
        
        Information("========================================");
        Information("TEST COVERAGE REPORT GENERATED");
        Information("========================================");
        var htmlReportPath = $"{MakeAbsolute(Directory(coverageResultsDir))}/index.html";
        Information($"HTML Report: {htmlReportPath}");
        Information($"Coverage Directory: {MakeAbsolute(Directory(coverageResultsDir))}");
        
        // Display text summary if available
        var summaryFile = $"{coverageResultsDir}/Summary.txt";
        if (FileExists(summaryFile))
        {
            Information("Coverage Summary:");
            Information(System.IO.File.ReadAllText(summaryFile));
        }
        
        Information("========================================");
        
        // Open HTML report in browser
        Information("Opening coverage report in browser...");
        StartProcess("cmd", new ProcessSettings
        {
            Arguments = $"/c start \"\" \"{htmlReportPath}\""
        });
    }
    else
    {
        Warning("No coverage files found!");
        Information($"Looking for coverage files in: {testResultsDir}");
        
        var allFiles = GetFiles($"{testResultsDir}/**/*");
        Information("Files found:");
        foreach(var file in allFiles)
        {
            Information($"  {file}");
        }
    }
});

Task("Coverage")
    .IsDependentOn("TestReport");

Task("Default")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);