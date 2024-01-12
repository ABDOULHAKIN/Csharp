using GestionApparts.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAppartsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //des appartements
            Appartement t1 = new Appartement("T1", 35);
            Appartement studio = new Appartement("Studio", 16);
            Appartement t3 = new Appartement("T3", 70);

            //des personnes
            Personne edmond = new Personne("BONSAPIN", "Edmond");
            Personne sasha = new Personne("HUTAUFOND", "Sasha");
            Personne adhemar = new Personne("PAMAMOBE", "Adhémar");
            Personne melanie = new Personne("MALALANICHE", "Mélanie");

            //associer des locataires aux appartements
            t1.Locataire = sasha;
            studio.Locataire = adhemar;
            t3.Locataire = edmond;

            //associer des propriétaires aux appartements
            t1.Proprietaire = edmond;
            studio.Proprietaire = edmond;
            t3.Proprietaire = melanie;

            //afficher les caractéristiques de chaque appartement
            Console.WriteLine("_________________________ Appartements ___________________________");
            Console.WriteLine(t1.ToString());
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(studio.ToString());
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(t3.ToString());
            Console.WriteLine("------------------------------------------------------------------");

            //afficher les caractéristiques de chaque personne 
            //et la liste de leur propriété si elles sont propriétaires
            Console.WriteLine("___________________________ Personnes_____________________________");
            Console.WriteLine(edmond.ToString());
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(sasha.ToString());
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(adhemar.ToString());
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(melanie.ToString());
            Console.WriteLine("------------------------------------------------------------------");

            //tester le changement de propriétaire (melanie devient la propriétaire du studio)
            studio.Proprietaire = melanie;
            Console.WriteLine("___________ Melanie devient la propriétaire du studio_____________");
            Console.WriteLine(edmond.ToString());
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(melanie.ToString());
            Console.WriteLine("------------------------------------------------------------------");

            Console.WriteLine("Appuyez sur une touche pour sortir de l'application.");
            Console.ReadKey();
        }
    }
}
