using System;
using System.IO;

namespace PasswordCracker.FileManagers;

public static class ResultLogger
{
    private static string LogPath => "log.txt";
    private static StreamWriter Log { get; } = File.AppendText(LogPath!);

    public static void LogResult(string result)
    {
        Log.WriteLine($"{DateTime.Now}: {result}");
    }
}