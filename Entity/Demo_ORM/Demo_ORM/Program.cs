namespace Demo_ORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext dbContext = new ApplicationContext();

            //-----------------------Partie 1---------------------------------------

            // Ajouter des personnes dans la BDD

            dbContext.Personnes.Add(new Personne() { Nom = "Mohamed Omar", Age = 30 });
            dbContext.Personnes.Add(new Personne() { Nom = "Corentin Cesar", Age = 35 });
            dbContext.Personnes.Add(new Personne() { Nom = "Simone Roger", Age = 30 });



            dbContext.SaveChanges(); // Pour valider la transaction

            // Afficher  les personnes presentent dans la BDD

            Console.WriteLine( " Personnes : ");
            foreach (var item in dbContext.Personnes)
            {
                Console.WriteLine(item.Nom);
            }

            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine( "Consultation d'une personne par une clause de recherche : ");
            var p = dbContext.Personnes.SingleOrDefault(x => x.Nom == "Mohamed");

            Console.WriteLine("-----------------------------------------------------------------");

            p.Nom = "Gouled";
            dbContext.SaveChanges();

            Console.WriteLine("-----------------------------------------------------------------");
            // Retirer une personne dans la liste de BDD

            var personneGouled = dbContext.Personnes.SingleOrDefault(g => g.Nom == "Gouled");
            dbContext.Personnes.Remove(personneGouled);

            dbContext.SaveChanges();

            //-----------------------Partie 2---------------------------------------
        }
    }
}
