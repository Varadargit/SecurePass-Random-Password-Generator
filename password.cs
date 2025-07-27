using System;
using System.Text;

class PasswordGenerator
{
    static void Main()
    {
        Console.WriteLine("=== Password Generator ===");

        Console.Write("Enter password length: ");
        int length = int.Parse(Console.ReadLine());

        Console.Write("Include uppercase letters? (y/n): ");
        bool includeUpper = Console.ReadLine().ToLower() == "y";

        Console.Write("Include lowercase letters? (y/n): ");
        bool includeLower = Console.ReadLine().ToLower() == "y";

        Console.Write("Include numbers? (y/n): ");
        bool includeNumbers = Console.ReadLine().ToLower() == "y";

        Console.Write("Include symbols? (y/n): ");
        bool includeSymbols = Console.ReadLine().ToLower() == "y";

        string password = GeneratePassword(length, includeUpper, includeLower, includeNumbers, includeSymbols);

        if (string.IsNullOrEmpty(password))
        {
            Console.WriteLine("Error: No character sets selected.");
        }
        else
        {
            Console.WriteLine("\nGenerated Password: " + password);
        }
    }

    static string GeneratePassword(int length, bool upper, bool lower, bool numbers, bool symbols)
    {
        const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
        const string NUMBERS = "0123456789";
        const string SYMBOLS = "!@#$%^&*()-_=+[]{};:<>?/";

        StringBuilder charSet = new StringBuilder();

        if (upper) charSet.Append(UPPERCASE);
        if (lower) charSet.Append(LOWERCASE);
        if (numbers) charSet.Append(NUMBERS);
        if (symbols) charSet.Append(SYMBOLS);

        if (charSet.Length == 0) return null;

        StringBuilder password = new StringBuilder();
        Random rnd = new Random();

        for (int i = 0; i < length; i++)
        {
            int index = rnd.Next(0, charSet.Length);
            password.Append(charSet[index]);
        }

        return password.ToString();
    }
}
