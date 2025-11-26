namespace PasswordCracker;

using PasswordCracker.Services;

class Program
{
    static void Main(string[] args)
    {
        List<string>? passwords = null;
        List<string>? targetHashes = null;
        
        try
        {
            passwords = DictionaryLoader.LoadWords("Data/passwords.txt");
        }catch (FileNotFoundException)
        {
            Console.WriteLine("The passwords.txt file was not found.");
        }

        try
        {
            targetHashes = DictionaryLoader.LoadWords("Data/hashes.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The hashes.txt file was not found.");
        }

        if (passwords == null | targetHashes == null)
        {
            Console.WriteLine("Shutting down.");
        }
        else
        {
            var cracker = new PasswordCrackerService();

            var result = cracker.CrackPasswords(passwords, targetHashes);

            Console.WriteLine("=== Results ===");
            Console.WriteLine(result.ResultsText);

            Console.WriteLine("=== Statistics ===");
            Console.WriteLine(result.StatsText);
        }
    }
}