var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");
var rainWorldPath = Argument("rainWorldPath", string.Empty);

var projectName = "tvardero.DearDevTools";
var projectPath = $"./src/{projectName}";
var outputPath = $"./dist/{projectName}";

Task("Clean")
    .Does(() =>
{
    DotNetClean(projectPath);

    if (DirectoryExists(outputPath))
    {
        CleanDirectory(outputPath);
    }
    
    Information($"Cleaned project output");
});

Task("PackMod")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var pluginsPath = $"{outputPath}/plugins";

    DotNetPublish(projectPath, new DotNetPublishSettings
    {
        Configuration = configuration,
        OutputDirectory = pluginsPath
    });
    Information($"Built and copied .dll files");

    var modinfoSource = $"{projectPath}/modinfo.json";
    var modinfoTarget = $"{outputPath}/modinfo.json";

    if (FileExists(modinfoSource))
    {
        CopyFile(modinfoSource, modinfoTarget);
        Information($"Copied modinfo.json");
    }
    else
    {
        Warning($"File not found: {modinfoSource}");
    }

    var thumbnailSource = $"{projectPath}/thumbnail.png";
    var thumbnailTarget = $"{outputPath}/thumbnail.png";

    if (FileExists(thumbnailSource))
    {
        CopyFile(thumbnailSource, thumbnailTarget);
        Information($"Copied thumbnail.png");
    }
    else
    {
        Warning($"File not found: {thumbnailSource}");
    }
    
    Information($"Done packing the mod");
});

Task("CopyModToRW")
    .IsDependentOn("PackMod")
    .Does(() =>
{
    rainWorldPath = rainWorldPath?.Trim();
        
    if (string.IsNullOrEmpty(rainWorldPath)) 
    {
        rainWorldPath = EnvironmentVariable("RAINWORLD_PATH");
        rainWorldPath = rainWorldPath?.Trim();
    }
    
    if (string.IsNullOrEmpty(rainWorldPath)) 
    {
        rainWorldPath = ReadEnvFile("RAINWORLD_PATH");
        rainWorldPath = rainWorldPath?.Trim();        
    }
    
    if (string.IsNullOrEmpty(rainWorldPath)) 
        throw new Exception("Rain World installation path is required. Specify it with --rainWorldPath argument, "
                          + "RAINWORLD_PATH environment variable or with .env or .env.local file.");

    var rainWorldModsPath = $"{rainWorldPath}/RainWorld_Data/StreamingAssets/mods";
    var modPath = $"{rainWorldModsPath}/{projectName}";

    if (!DirectoryExists(modPath))
    {
        CreateDirectory(modPath);
    }
    else
    {
        CleanDirectory(modPath);
    }

    CopyDirectory(outputPath, modPath);
    Information($"Copied packed mod to {modPath}");
});

Task("Default")
    .IsDependentOn("CopyModToRW");

RunTarget(target);

// Helper method to read environment variable from .env files
string ReadEnvFile(string key)
{
    var envFiles = new[] { ".env.local", ".env" };

    foreach (var envFile in envFiles)
    {
        if (FileExists(envFile))
        {
            var lines = System.IO.File.ReadAllLines(envFile);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                    continue;

                var parts = line.Split(new[] { '=' }, 2);
                if (parts.Length == 2 && parts[0].Trim() == key)
                {
                    var value = parts[1].Trim();
                    
                    // Remove surrounding quotes if present
                    if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                        (value.StartsWith("'") && value.EndsWith("'")))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }
                    return value;
                }
            }
        }
    }

    return null;
}