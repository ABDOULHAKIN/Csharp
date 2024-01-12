using System.Data.SqlTypes;
using System.Globalization;

namespace Palalalalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\Sources\palindrome\Grand palindrome.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine($"Ce chemin est invalide :{path}");
                return;
            }
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (!line.Any()) continue;

                if (IsPalindrome(line))
                    Console.WriteLine($"{line} : est un palindrome");
                else
                    Console.WriteLine($"{line} : n'est pas un palindrome");
            }
        }

        private static bool IsPalindrome(string line)
        {
            line = line.Replace(" ", "");
            var reversed = new string(line.Reverse().ToArray());
            var comparer = StringComparer.Create(
                CultureInfo.CurrentCulture,
                CompareOptions.IgnoreCase | CompareOptions.IgnoreSymbols
                | CompareOptions.IgnoreNonSpace);
            return comparer.Compare(line, reversed) == 0;
        }
    }
}