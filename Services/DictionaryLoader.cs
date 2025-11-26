namespace PasswordCracker.Services;

public static class DictionaryLoader
{
    public static List<string> LoadWords(string path)
    {
        return File.ReadAllLines(path)
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();
    }
}