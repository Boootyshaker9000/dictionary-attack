using PasswordCracker.Models;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace PasswordCracker.Services;

public class PasswordCrackerService
{
    public CrackResult CrackPasswords(List<string> dictionary, List<string> targetHashes)
    {
        var result = new CrackResult();
        var found = new ConcurrentBag<(string Password, string Hash)>();
        var stats = new CrackStats();

        var targetSet = new HashSet<string>(targetHashes);
        var stopwatch = Stopwatch.StartNew();

        Parallel.ForEach(dictionary, password =>
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