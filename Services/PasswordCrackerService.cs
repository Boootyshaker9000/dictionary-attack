using PasswordCracker.Models;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace PasswordCracker.Services;

/// <summary>
/// Class searching for matching hash values
/// </summary>
public class PasswordCrackerService
{
    /// <summary>
    /// Searches for a match between a password hash and a target hash
    /// </summary>
    /// <param name="passwordHashes">A List instance of hashed passwords</param>
    /// <param name="targetHashes">A hash instance of target hashes</param>
    /// <returns>result of search</returns>
    public CrackResult CrackPasswords(List<string> passwordHashes, List<string> targetHashes)
    {
        var result = new CrackResult();
        var found = new ConcurrentBag<(string Password, string Hash)>();
        var stats = new CrackStats();

        var targetSet = new HashSet<string>(targetHashes);
        var stopwatch = Stopwatch.StartNew();

        Parallel.ForEach(passwordHashes, password =>
        {
            string hash = HashUtils.ComputeSha256(password);

            Interlocked.Increment(ref stats.TestedWords);

            if (targetSet.Contains(hash))
            {
                found.Add((password, hash));
            }
        });

        stopwatch.Stop();

        result.Found = found.ToList();
        stats.ElapsedMilliseconds = stopwatch.ElapsedMilliseconds;
        result.Stats = stats;

        return result;
    }
}