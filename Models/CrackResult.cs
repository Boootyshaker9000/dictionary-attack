namespace PasswordCracker.Models;

public class CrackResult
{
    public List<(string Password, string Hash)> Found { get; set; } = new();

    public CrackStats Stats { get; set; } = new();

    public string ResultsText =>
        string.Join("\n", Found.Select(x => $"Password: {x.Password} -> {x.Hash}"));
    
    public string StatsText =>
        $"Passwords tested: {Stats.TestedWords}\n" +
        $"Found: {Found.Count}\n" +
        $"Runtime: {Stats.ElapsedMilliseconds} ms";
}