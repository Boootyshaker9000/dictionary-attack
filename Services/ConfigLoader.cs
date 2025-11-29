using System.Text.Json;

namespace PasswordCracker.Services;

public static class ConfigLoader
{
    /// <summary>
    /// Checks if config file exists. If so, it will return the config file as an instance of Dictionary. If not, null will be returned.
    /// </summary>
    /// <param name="configPath">Config file path</param>
    /// <returns>Configuration options as a dictionary.</returns>
    public static Dictionary<string, string>? ConfigFile(string configPath)
    {
        Dictionary<string, string>? config;
        try
        {
            string json = File.ReadAllText(configPath);
            config = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFoundException();
        }

        return config;
    }
}