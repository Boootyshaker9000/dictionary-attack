namespace PasswordCracker.Services;

/// <summary>
/// Static class for saving output into a text file
/// </summary>
public static class ResultSaver
{
    /// <summary>
    /// Saves matches into a text file
    /// </summary>
    /// <param name="filePath">File path of the output file</param>
    /// <param name="matches">List of pairs of passwords and matched hashes</param>
    public static void SaveMatches(string filePath, List<(string password, string hash)> matches)
    {
        using var matchFile = File.CreateText(filePath);
        foreach (var match in matches)
        {
            matchFile.WriteLine($"{match.password} -> {match.hash}");
        }
    }
}