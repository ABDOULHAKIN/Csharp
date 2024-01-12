using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01_TempsCuisson
{
    /**
     * Application de calcul d'un temps de cuisson en secondes
     * en fonction du type de viande(PORC ou BOEUF), d'un mode
     * de cuisson(BLEU, A POINT, BIEN CUIT) et d'un coefficent 
     * de référence fourni par notre chef étoilé.
     */
 
    
    class Program
    {
        static void Main(string[] args)
        {
            // variables et constantes
            int viande, cuisson, poids;
            float coefficient = 0;
            const byte BOEUF = 1;
            const byte PORC = 2;
            const byte BLEU = 1;
            const byte A_POINT = 2;
            const byte BIEN_CUIT = 3;
            const byte UNE_MINUTE = 60;
            const float BLEU_B = (float)(10.0 / 500.0);
            const float A_PT_B = (float)(17.0 / 500.0);
            const float B_CU_B = (float)(25.0 / 500.0);
            const float BLEU_P = (float)(15.0 / 400.0);
            const float A_PT_P = (float)(25.0 / 400.0);
            const float B_CU_P = (float)(40.0 / 400.0);

			//saisie des informations
			Console.WriteLine("Viande ?"); // Choix du type de viande
			Console.WriteLine(BOEUF + " – Boeuf");
			Console.WriteLine(PORC + " – Porc");
			//Faire saisir une valeur numérique à l'utilisateur
			//miniminise le risque d'erreur et facilite la saisie
			//et facilite le test dans le programme
			int.TryParse(Console.ReadLine(), out viande);
			Console.WriteLine("Cuisson ?"); // Choix du type de cuisson
			Console.WriteLine(BLEU + " – Bleu");
			Console.WriteLine(A_POINT + " – A point");
			Console.WriteLine(BIEN_CUIT + " – Bien cuit");
			int.TryParse(Console.ReadLine(), out cuisson);
			Console.WriteLine("Poids en gramme ?"); // Choix du poids de la viande
			int.TryParse(Console.ReadLine(), out poids);

			//traitement du calcul
			switch (viande)
			{
				case BOEUF:
					if (cuisson == BLEU)
					{
						coefficient = BLEU_B;
					}
					else if (cuisson == A_POINT)
					{
						coefficient = A_PT_B;
					}
					else if (cuisson == BIEN_CUIT)
					{
						coefficient = B_CU_B;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Ce mode de cuisson n'est pas pris en compte !");
						Console.ResetColor();
					}
					break; //sortir du cas BOEUF
				case PORC:
					if (cuisson == BLEU)
					{
						coefficient = BLEU_P;
					}
					else if (cuisson == A_POINT)
					{
						coefficient = A_PT_P;
					}
					else if (cuisson == BIEN_CUIT)
					{
						coefficient = B_CU_P;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Ce mode de cuisson n'est pas pris en compte !");
						Console.ResetColor();
					}
					break; //sortir du cas PORC
				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Ce type de viande n'est pas pris en compte !");
					Console.ResetColor();
					break;
			}

			//affichage du résultat
			Console.WriteLine("Le temps de cuisson est de " + (poids * coefficient * UNE_MINUTE) + " secondes");

			Console.WriteLine("Appuyez sur une touche pour sortir de l'application.");
			Console.ReadKey();

		}
	}
}
