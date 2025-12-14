using System;
using System.IO;

namespace PasswordCracker.FileManagers;

public static class ResultLogger
{
    public static void LogResult(string result)
    {
        File.AppendAllText("log.txt", $"{DateTime.Now}: {result}{Environment.NewLine}");
    }
}