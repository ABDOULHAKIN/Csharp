namespace TpCastle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Combien d'étages ?");
            var floorCount = int.Parse(Console.ReadLine());
            const string castle = @"/\";
            var buffer = castle;

            for (int i = floorCount - 1; i >= 0; i--)
            {
                var spacebuffer = "".PadLeft(i);// PadLeft va ajouter des espaces à gauche de la variable
                                                // sur laquelle on l'appelle, pour arriver à une taille
                                                // de string totale égale au nombre passé en paramètre
                Console.WriteLine(spacebuffer + buffer);
                buffer += castle;
            }
        }
    }
}