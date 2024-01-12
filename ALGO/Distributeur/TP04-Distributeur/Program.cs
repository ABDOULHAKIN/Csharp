using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TP04_Distributeur
{
    class Program
    {
        static void Main(string[] args)
        {
			const float PRIX_CAFE = 0.60f;
			int credit = 0;
			int rendu = 0;
			int nbPieces = 0;

			// Stock des pièces
			int nb_pieces_200 = 0, nb_pieces_100 = 0,
				nb_pieces_050 = 0, nb_pieces_020 = 0, 
				nb_pieces_010 = 0, nb_pieces_005 = 0;

			//affichage du stock de pièces
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Stock des pièces");
			Console.WriteLine($" - {nb_pieces_200} piece(s) de 2 Euro");
			Console.WriteLine($" - {nb_pieces_100} piece(s) de 1 Euro");
			Console.WriteLine($" - {nb_pieces_050} piece(s) de 0.50 Euro");
			Console.WriteLine($" - {nb_pieces_020} piece(s) de 0.20 Euro");
			Console.WriteLine($" - {nb_pieces_010} piece(s) de 0.10 Euro");
			Console.WriteLine($" - {nb_pieces_005} piece(s) de 0.05 Euro");
			Console.ResetColor();

			//faire l'appoint
			Console.WriteLine("Faites l'appoint (pièces acceptées : 0.05, 0.10, 0.20, 0.50, 1, 2) Euro : ");

			do
			{
				float saisie;
				float.TryParse(Console.ReadLine(), out saisie);
				//passer la saisie en entier pour éviter les problèmes d'arrondi
				int saisieCentimes = (int)(saisie * 100);
				if (saisieCentimes == 5 || saisieCentimes == 10 || saisieCentimes == 20 || 
					saisieCentimes == 50 || saisieCentimes == 100 || saisieCentimes == 200)
				{
					credit = credit + saisieCentimes;
					if (credit < (PRIX_CAFE * 100))
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("Crédit insuffisant (" + credit / 100.0 + " Euro / " + PRIX_CAFE + " Euro)");
						Console.ResetColor();
					}

					//Les pièces introduites par le consommateur s'ajoutent au stock
					if (saisieCentimes == 200) nb_pieces_200++;
					if (saisieCentimes == 100) nb_pieces_100++;
					if (saisieCentimes == 50) nb_pieces_050++;
					if (saisieCentimes == 20) nb_pieces_020++;
					if (saisieCentimes == 10) nb_pieces_010++;
					if (saisieCentimes == 5) nb_pieces_005++;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Pièce non acceptée !");
					Console.ResetColor();
				}
			} while (credit < (PRIX_CAFE * 100));

			Console.Clear();
			//servir la boisson
			Console.Write("Boisson en préparation");
			byte secondes = 0;
			do
			{
				Console.Write("."); //juste pour l'effet....
				Thread.Sleep(1000);
				secondes++;
				
			} while (secondes < 4);

			//rendre la monnaie
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Stock des pièces");
			Console.WriteLine($" - {nb_pieces_200} piece(s) de 2 Euro");
			Console.WriteLine($" - {nb_pieces_100} piece(s) de 1 Euro");
			Console.WriteLine($" - {nb_pieces_050} piece(s) de 0.50 Euro");
			Console.WriteLine($" - {nb_pieces_020} piece(s) de 0.20 Euro");
			Console.WriteLine($" - {nb_pieces_010} piece(s) de 0.10 Euro");
			Console.WriteLine($" - {nb_pieces_005} piece(s) de 0.05 Euro");
			Console.ResetColor();

			rendu = credit - ((int)(PRIX_CAFE * 100));
			Console.WriteLine("Votre monnaie (" + rendu / 100.0 + " Euro)");

			//en pièces de 2 Euro
			if (rendu >= 200)
			{
				nbPieces = (int)(rendu / 200);
				if (nbPieces > 0 & nb_pieces_200 > 0)
				{
					//y a t il suffisamment de pieces de 2 Euro en stock ?
					if (nbPieces <= nb_pieces_200)
                    {
						//diminuer le stock des pieces de 2 Euro
						nb_pieces_200 -= nbPieces;
					} else
                    {
						//prendre toutes les pieces de 2 Euro disponibles en stock
						nbPieces = nb_pieces_200;
						//...et mettre le stock des pièces de 2 Euro à 0
						nb_pieces_200 = 0;
                    }
					rendu = rendu - (nbPieces * 200);
					Console.WriteLine("  -> " + nbPieces + " pièce(s) de 2 Euro");
				}
			}
			//en pièces de 1 Euro
			if (rendu >= 100)
			{
				nbPieces = (int)(rendu / 100);
				if (nbPieces > 0 & nb_pieces_100 > 0)
				{
					//y a t il suffisamment de pieces de 1 Euro en stock ?
					if (nbPieces <= nb_pieces_100)
					{
						//diminuer le stock des pieces de 1 Euro
						nb_pieces_100 -= nbPieces;
					}
					else
					{
						//prendre toutes les pieces de 1 Euro disponibles en stock
						nbPieces = nb_pieces_100;
						//...et mettre le stock des pièces de 1 Euro à 0
						nb_pieces_100 = 0;
					}
					rendu = rendu - (nbPieces * 100);
					Console.WriteLine("  -> " + nbPieces + " pièce(s) de 1 Euro");
				}
			}
			//en pièces de 0.5 Euro
			if (rendu >= 50)
			{
				nbPieces = (int)(rendu / 50);
				if (nbPieces > 0 & nb_pieces_050 > 0)
				{
					//y a t il suffisamment de pieces de 0.5 Euro en stock ?
					if (nbPieces <= nb_pieces_050)
					{
						//diminuer le stock des pieces de 0.5 Euro
						nb_pieces_050 -= nbPieces;
					}
					else
					{
						//prendre toutes les pieces de 0.5 Euro disponibles en stock
						nbPieces = nb_pieces_050;
						//...et mettre le stock des pièces de 0.5 Euro à 0
						nb_pieces_050 = 0;
					}
					rendu = rendu - (nbPieces * 50);
					Console.WriteLine("  -> " + nbPieces + " pièce(s) de 0,50 Euro");
				}
			}
			//en pièces de 0.2 Euro
			if (rendu >= 20)
			{
				nbPieces = (int)(rendu / 20);
				if (nbPieces > 0 & nb_pieces_020 > 0)
				{
					//y a t il suffisamment de pieces de 0.2 Euro en stock ?
					if (nbPieces <= nb_pieces_020)
					{
						//diminuer le stock des pieces de 0.2 Euro
						nb_pieces_020 -= nbPieces;
					}
					else
					{
						//prendre toutes les pieces de 0.2 Euro disponibles en stock
						nbPieces = nb_pieces_020;
						//...et mettre le stock des pièces de 0.2 Euro à 0
						nb_pieces_020 = 0;
					}
					rendu = rendu - (nbPieces * 20);
					Console.WriteLine("  -> " + nbPieces + " pièce(s) de 0,20 Euro");
				}
			}
			//en pièces de 0.1 Euro
			if (rendu >= 10)
			{
				nbPieces = (int)(rendu / 10);
				if (nbPieces > 0 & nb_pieces_010 > 0)
				{
					//y a t il suffisamment de pieces de 0.1 Euro en stock ?
					if (nbPieces <= nb_pieces_010)
					{
						//diminuer le stock des pieces de 0.1 Euro
						nb_pieces_010 -= nbPieces;
					}
					else
					{
						//prendre toutes les pieces de 0.1 Euro disponibles en stock
						nbPieces = nb_pieces_010;
						//...et mettre le stock des pièces de 0.1 Euro à 0
						nb_pieces_010 = 0;
					}
					rendu = rendu - (nbPieces * 10);
					Console.WriteLine("  -> " + nbPieces + " pièce(s) de 0,10 Euro");
				}
			}
			//en pièces de 0.05 Euro
			if (rendu >= 5)
			{
				nbPieces = (int)(rendu / 5);
				if (nbPieces > 0 & nb_pieces_005 > 0)
				{
					//y a t il suffisamment de pieces de 0.05 Euro en stock ?
					if (nbPieces <= nb_pieces_005)
					{
						//diminuer le stock des pieces de 0.05 Euro
						nb_pieces_005 -= nbPieces;
					}
					else
					{
						//prendre toutes les pieces de 0.05 Euro disponibles en stock
						nbPieces = nb_pieces_005;
						//...et mettre le stock des pièces de 0.05 Euro à 0
						nb_pieces_005 = 0;
					}
					rendu = rendu - (nbPieces * 5);
					Console.WriteLine("  -> " + nbPieces + " pièce(s) de 0,05 Euro");
				}
			}

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Stock des pièces");
			Console.WriteLine($" - {nb_pieces_200} piece(s) de 2 Euro");
			Console.WriteLine($" - {nb_pieces_100} piece(s) de 1 Euro");
			Console.WriteLine($" - {nb_pieces_050} piece(s) de 0.50 Euro");
			Console.WriteLine($" - {nb_pieces_020} piece(s) de 0.20 Euro");
			Console.WriteLine($" - {nb_pieces_010} piece(s) de 0.10 Euro");
			Console.WriteLine($" - {nb_pieces_005} piece(s) de 0.05 Euro");
			Console.ResetColor();

			if (rendu > 0)
            {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Désolé ! Plus de monnaie en stock. Nous vous devons {rendu / 100.0} Euro.");
				Console.ResetColor();
            }



			Console.WriteLine("Appuyez sur une touche pour sortir de l'application.");
			Console.ReadKey();
		}
    }
}
