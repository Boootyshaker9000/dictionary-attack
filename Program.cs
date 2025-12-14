using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordCracker;

using Services;
using FileManagers;

class Program
{
    static void Main()
    {
        Dictionary<string, string>? config;
        try
        {
            config = ConfigLoader.ConfigFile("config.json");

            List<string> keys =
            [
                "passwords",
                "hashes",
                "matches"

            ];

            foreach (var key in config!.Keys)
            {
                if (!keys.Contains(key))
                {
                    ResultLogger.LogResult($"Error: The {key} key is invalid.");
                    return;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The config.json file was not found.");
            return;
        }

        List<string>? passwords = null;
        List<string>? targetHashes = null;

        try
        {
            passwords = DictionaryLoader.LoadLines(config["passwords"]);
        }
        catch (FileNotFoundException)
        {
            ResultLogger.LogResult($"Error: The \'{passwords}\' file was not found.");
            return;
        }/*
        catch (NullReferenceException)
        {
            Console.WriteLine($"Error: The \'{passwords}\' cannot be read, because config.json is missing.");
            return;
        }*/

        try
        {
            targetHashes = DictionaryLoader.LoadLines(config!["hashes"]);
        }
        catch (FileNotFoundException)
        {
            ResultLogger.LogResult($"Error: The \'{targetHashes}\' file was not found.");
            return;
        }/*
        catch (NullReferenceException)
        {
            Console.WriteLine($"The \'{targetHashes}\' cannot be read, because config.json is missing.");
        }*/
        
        var cracker = new PasswordCrackerService();

        var result = cracker.CrackPasswords(passwords!, targetHashes!);

        ResultSaver.SaveMatches(config["matches"], result.Found);
        
        ResultLogger.LogResult(result.StatsText);
    }
}