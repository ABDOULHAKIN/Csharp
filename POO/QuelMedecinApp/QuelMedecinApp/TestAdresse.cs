//Ajouter la référence au projet BO
using QuelMedecin.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuelMedecinApp
{
    class TestAdresse
    {
        static void Main(string[] args)
        {
			Console.WriteLine("__________________________ Adresses ______________________________");
			Adresse sh = new Adresse("ZAC du Moulin Neuf", 2, "B", "rue Benjamin Franklin", 44800, "Saint Herblain");
			Adresse nio = new Adresse(19, null, "avenue Léo Lagrange", 79000, "Niort");
			Adresse comp = new Adresse(4, null, "Rue des Glatiniers", 2100, "Saint-Quentin");

			//sh.Afficher() //l'utilisation de cette méthode est dépréciée 
			//(cf annotation [obselete] devant la méthode dans la classe Adresse)
			Console.WriteLine(sh.ToString());
			Console.WriteLine("------------------------------------------------------------------");
			Console.WriteLine(nio.ToString());
			Console.WriteLine("------------------------------------------------------------------");
			Console.WriteLine(comp.ToString());

			Console.WriteLine("Appuyez sur une touche pour sortir de l'application.");
			Console.ReadKey();
		}
    }
}
