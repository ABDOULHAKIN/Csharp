
namespace TpLievreTortue.Ihm
{
    internal class Program
    {
        public static int MyProperty { get; set; }
        static void Main(string[] args)
        {
            int lievreWon = 0;
            int tortueWon = 0;

            const int count = 1_000_000_000;
            for (int i = 0; i < count; i++)
            {
                if (leLievreAGagne())
                    lievreWon++;
                else
                    tortueWon++;
            }
            var probaTortue = Math.Pow(5d / 6, 4);
            var probaLievre = 1 - probaTortue;
            Console.WriteLine($"Simulation : Le lièvre a gagné {lievreWon * 1d / count}");
            Console.WriteLine($"Simulation : La tortue a gagné {(double)tortueWon / count}");
            Console.WriteLine($"proba calculé win tortue       {probaTortue}");
            Console.WriteLine($"proba calculé win lièvre       {probaLievre}");
        }

        private static bool leLievreAGagne()
        {
            for (int i = 0; i < 4; i++)
            {
                if (Random.Shared.Next(6) == 0)
                    return true;
            }
            return false;
        }
    }
}