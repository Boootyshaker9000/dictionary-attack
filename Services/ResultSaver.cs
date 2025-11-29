namespace PasswordCracker.Services;

public static class ResultSaver
{
    public static void SaveMatches(string filePath, List<(string password, string hash)> matches)
    {
        using var matchFile = File.CreateText(filePath);
        foreach (var match in matches)
        {
            matchFile.WriteLine($"{match.password} -> {match.hash}");
        }
    }
}