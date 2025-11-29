namespace PasswordCracker;

using Services;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string>? config = ConfigLoader.ConfigFile("config.json");
        
        List<string>? passwords = null;
        List<string>? targetHashes = null;
        
        try
        {
            passwords = DictionaryLoader.LoadLines(config!["passwords"]);
        }catch (FileNotFoundException)
        {
            Console.WriteLine($"The \'{passwords}\' file was not found.");
        }

        try
        {
            targetHashes = DictionaryLoader.LoadLines(config!["hashes"]);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"The \'{targetHashes}\' file was not found.");
        }

        if (passwords == null | targetHashes == null)
        {
            Console.WriteLine("Shutting down.");
        }
        else
        {
            var cracker = new PasswordCrackerService();

            var result = cracker.CrackPasswords(passwords, targetHashes);

            ResultSaver.SaveMatches(config!["matches"], result.Found);
            
            Console.WriteLine("====Statistics====");
            Console.WriteLine(result.StatsText);
        }
    }
}