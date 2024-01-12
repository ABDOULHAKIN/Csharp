using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP05_PalindromePhrase
{
    class Program
    {
        static void Main(string[] args)
        {
			// Déclarations
			String chaineSaisie;
			String chaineATester = String.Empty;

			char[,] accents = new char[,] {
				{ 'é','è','ê','à','ù','ô','ë','â','î','ï','ç'},
					{ 'e','e','e','a','u','o','e','a','i','i','c'}
			}; // Matrice de correspondance des caractères accentués en caractères sans accent

			char[] ponctuations = new char[] { 
				' ',',', ';', '.', '/', ':', '\'', '?', '!', '(', ')', '-' 
			}; //Matrice des ponctuations

			// Initialisation de la variable de travail chaineSaisie 
			// contenant la chaine a etudier
			Console.WriteLine("Saisir la chaine à tester : ");
			chaineSaisie = Console.ReadLine();
			Console.WriteLine("Votre chaine : \"" + chaineSaisie + "\"");

			// Elimination des problèmes de casse de caractère
			chaineATester = chaineSaisie.ToLower();
			Console.WriteLine("Votre chaine minuscule : \"" + chaineATester + "\"");

			// Elimination des accents
			for (int i = 0; i < accents.GetLength(0); i++)
			{
				chaineATester = chaineATester.Replace(accents[0,i], accents[1,i]);
			}
			Console.WriteLine("Votre chaine sans accents : \"" + chaineATester + "\"");

			// Elimination de la ponctuation et des espaces
			String[] mots = chaineATester.Split(ponctuations);
			chaineATester = String.Empty;
			foreach (String mot in mots) {
				chaineATester = chaineATester + mot;
			}
			Console.WriteLine("Votre chaine sans ponctuation : \"" + chaineATester + "\"");

			// Construire la chaine inverse
			char[] charArray = chaineATester.ToCharArray();
			Array.Reverse(charArray);
			String chaineInversee =  new string(charArray);
			Console.WriteLine("Votre chaine inversée : \"" + chaineInversee + "\"");

			// Tester le palidrome
			Console.WriteLine("La phrase :");
			Console.WriteLine(chaineSaisie);
			if (chaineATester.Equals(chaineInversee)) {
				Console.WriteLine("est un palyndrome");
			}
			else {
				Console.WriteLine("n'est pas un palyndrome.");
			}

			Console.WriteLine("Appuyez sur une touche pour sortir de l'application.");
			Console.ReadKey();
		}
    }
}
