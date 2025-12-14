using System.IO;

namespace PasswordCracker.Services;

public static class ResultLogger
{
    public static string logPath { set; get; }
    private static StreamWriter log { get; } = File.CreateText(logPath);

    public static void LogResult(string result)
    {
        log.WriteLine(result);
    }
}