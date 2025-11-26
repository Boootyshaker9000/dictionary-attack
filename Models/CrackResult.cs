namespace PasswordCracker.Models;

/// <summary>
/// Class representing results of password cracking test
/// </summary>
public class CrackResult
{
    /// <summary>
    /// List of all passwords matched with a hash
    /// </summary>
    public List<(string Password, string Hash)> Found { get; set; } = new();

    /// <summary>
    /// Statistics of the test
    /// </summary>
    /// <see cref="CrackStats"/>
    public CrackStats Stats { get; set; } = new();

    /// <summary>
    /// Text showing matched passwords and their hash
    /// </summary>
    public string ResultsText =>
        string.Join("\n", Found.Select(foundPassword => $"Password: {foundPassword.Password} -> {foundPassword.Hash}"));
    
    /// <summary>
    /// Text showing final statistics of the test
    /// </summary>
    public string StatsText =>
        $"Passwords tested: {Stats.TestedWords}\n" +
        $"Found: {Found.Count}\n" +
        $"Runtime: {Stats.ElapsedMilliseconds} ms";
}