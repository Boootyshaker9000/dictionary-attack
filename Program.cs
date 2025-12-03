namespace PasswordCracker;

using Services;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string>? config = null;
        try
        {
            config = ConfigLoader.ConfigFile("config.json");

            List<string> keys = new List<string>();
            keys.Add("passwords");
            keys.Add("hashes");
            keys.Add("matches");
            
            foreach (var key in config!.Keys)
            {
                if (!keys.Contains(key))
                {
                    Console.WriteLine($"The {key} key has been renamed.");
                    Console.WriteLine("Shutting down.");
                    return;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"The config.json file was not found.");
        }

        List<string>? passwords = null;
        List<string>? targetHashes = null;

        try
        {
            passwords = DictionaryLoader.LoadLines(config!["passwords"]);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"The \'{passwords}\' file was not found.");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine($"The \'{passwords}\' cannot be read, because config.json is missing.");
        }

        try
        {
            targetHashes = DictionaryLoader.LoadLines(config!["hashes"]);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"The \'{targetHashes}\' file was not found.");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine($"The \'{targetHashes}\' cannot be read, because config.json is missing.");
        }

        if (passwords == null | targetHashes == null)
        {
            Console.WriteLine("Shutting down.");
            return;
        }
        
        var cracker = new PasswordCrackerService();

        var result = cracker.CrackPasswords(passwords!, targetHashes!);

        ResultSaver.SaveMatches(config!["matches"], result.Found);
        
        Console.WriteLine("====Statistics====");
        Console.WriteLine(result.StatsText);
    }
}