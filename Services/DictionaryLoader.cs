namespace PasswordCracker.Services;

public static class DictionaryLoader
{
    /// <summary>
    /// Loads data from text files
    /// </summary>
    /// <param name="path"></param>
    /// <returns>A List instance of individual values loaded from a text file</returns>
    public static List<string> LoadWords(string path)
    {
        return File.ReadAllLines(path)
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();
    }
}