using GestionComptes.BO;
using System;
using System.Text;

namespace GestionComptesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CompteEpargne compte1 = new CompteEpargne("MARTIN", DateTime.Now);
            CompteEpargne compte2 = new CompteEpargne("DUPONT", DateTime.Now, 1000.0);
            ComptePayant compte3 = new ComptePayant("DURANT", new DateTime(2020, 09, 25), 1.5f);

            //afficher les 3 comptes après création 
            Console.WriteLine();
            Console.WriteLine("_______________ Visualisation des 3 comptes créés _______________");
            Console.WriteLine(compte1.Visualiser());
            Console.WriteLine(compte2.Visualiser());
            Console.WriteLine(compte3.Visualiser());
            //possibilité de créditer et débiter les comptes 
            compte1.Crediter(350.0);
            compte3.Crediter(870.32);
            //afficher les 3 comptes après les opérations 

            Console.WriteLine();
            Console.WriteLine("_ Visualisation des comptes apres dépot de 350 euro sur compte 1, 870,32 euro sur compte 3 _");
            Console.WriteLine(compte1.Visualiser());
            Console.WriteLine(compte2.Visualiser());
            Console.WriteLine(compte3.Visualiser());
            //afficher les 3 comptes après le calcul des intérets sur le compte 2 
            Console.WriteLine();
            Console.WriteLine("_ Visualisation des comptes apres calcul des interets sur compte 2 _");
            compte2.CalculerInteret();
            Console.WriteLine(compte1.Visualiser());
            Console.WriteLine(compte2.Visualiser());
            Console.WriteLine(compte3.Visualiser());
            //afficher le nombre de comptes instanciés 
            Console.WriteLine();
            Console.WriteLine($"nombre d'instances de compte créées : {Compte.VoirGenerateurCompte()}");
            Console.ReadKey();
        }
    }
}
