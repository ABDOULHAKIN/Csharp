using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02_Bulletinssalaire
{
    class Program
    {
        static void Main(string[] args)
        {
			// Calcul un bulletin de salaire
			String nom, prenom;
			byte statut; //1 pour cadre, 2 pour agent de maitrise, 3 pour employe
			float prime, tx;
			byte nbenf;
			short nbheure;
			double sal_base, sal_net, cotis;
			const float RDS = 0.0349f;
			const float CSG = 0.0615f;
			const float MALADIE = 0.0095f;
			const float VIEILLESSE = 0.0844f;
			const float CHOMAGE = 0.0305f;
			const float RETRAITE = 0.0381f;
			const float AGFF = 0.0102f;
			const float BASE_LEGAL_HEURE = 169f;
			const float BASE_LEGAL_MAJORATION = 180f;
			const float TAUX_MAJORATION_BAS = 0.5f;
			const float TAUX_MAJORATION_HAUT = 0.6f;

			Console.Write("Nom ? ");
			nom = Console.ReadLine();
			Console.Write("Prénom ? ");
			prenom = Console.ReadLine();
			Console.Write("Statut (1 pour cadre, 2 pour agent de maitrise, 3 pour employe) ? ");
			byte.TryParse(Console.ReadLine(), out statut);
			Console.Write("Nombre d'heures travaillées ? ");
			short.TryParse(Console.ReadLine(), out nbheure);
			Console.Write("Taux horaire du salarié ? ");
			float.TryParse(Console.ReadLine(), out tx);
			Console.Write("Nombre d'enfants ? ");
			byte.TryParse(Console.ReadLine(), out nbenf);

			//calcul salaire brut
			if (nbheure <= BASE_LEGAL_HEURE)
			{
				sal_base = nbheure * tx;
			}
			else if (nbheure < BASE_LEGAL_MAJORATION)
			{
				//les 169èmes heures sont au taux normal, 
				//les heures sup comprises entre 169 et 180 sont majorées de 50%
				sal_base = (BASE_LEGAL_HEURE * tx) +
						((nbheure - BASE_LEGAL_HEURE) * tx * (1 + TAUX_MAJORATION_BAS));
			}
			else
			{
				//les 169èmes heures sont au taux normal, 
				//les heures sup comprises entre 169 et 180 sont majorées de 50%
				//les heures sup au dela 180 sont majorées de 60%
				sal_base = (BASE_LEGAL_HEURE * tx) +
						((BASE_LEGAL_MAJORATION - BASE_LEGAL_HEURE) * tx * (1 + TAUX_MAJORATION_BAS))
						+ ((nbheure - BASE_LEGAL_MAJORATION) * tx * (1 + TAUX_MAJORATION_HAUT));
			}

			//calcul prime
			switch (nbenf)
			{
				case 0:
					prime = 0;
					break;
				case 1:
					prime = 20;
					break;
				case 2:
					prime = 50;
					break;
				default:
					prime = 70 + ((nbenf - 2) * 20);
					break;
			}

			//calcul cotisation
			cotis = (sal_base * RDS) + (sal_base * CSG) + (sal_base * MALADIE) +
					(sal_base * VIEILLESSE) + (sal_base * CHOMAGE) +
					(sal_base * RETRAITE) + (sal_base * AGFF);

			//affichage du bulletin
			sal_net = sal_base + prime - cotis;

			Console.Clear();
			Console.WriteLine("IMPRESSION DU BULLETIN DE SALAIRE");
			Console.WriteLine("Salarié : " + nom + " " + prenom);
			Console.WriteLine("Salaire de base : " + sal_base + " Euros");
			Console.WriteLine("Cotisations : " + cotis + " Euros");
			Console.WriteLine("Prime : " + prime + " Euros");
			Console.WriteLine("Salaire Net : " + sal_net + " Euros");

			Console.WriteLine("Appuyez sur une touche pour sortir de l'application.");
			Console.ReadKey();
		}
    }
}
