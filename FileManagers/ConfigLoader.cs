using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PasswordCracker.FileManagers;

public static class ConfigLoader
{
    /// <summary>
    /// Checks if config file exists. If so, it will return the config file as an instance of Dictionary. If not, null will be returned.
    /// </summary>
    /// <param name="configPath">Config file path</param>
    /// <returns>Configuration options as a dictionary with string keys and string values.</returns>
    public static Dictionary<string, string>? ConfigFile(string configPath)
    {
        string json = File.ReadAllText(configPath);
        return JsonSerializer.Deserialize<Dictionary<string, string>>(json);
    }
}