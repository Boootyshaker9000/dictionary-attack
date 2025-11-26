namespace PasswordCracker.Models;

/// <summary>
/// Class representing current state of the test
/// </summary>
public class CrackStats
{
    /// <summary>
    /// Counter of passwords already tested
    /// </summary>
    public int TestedWords;
    
    /// <summary>
    /// Time elapsed since the test began
    /// </summary>
    public long ElapsedMilliseconds { get; set; }
}