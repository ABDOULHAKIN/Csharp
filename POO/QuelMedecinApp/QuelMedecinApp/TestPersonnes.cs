using QuelMedecin.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuelMedecinApp
{
    public class TestPersonnes
    {
        //les instances utilisées pour le test
        private static MedecinGeneraliste melanie = new MedecinGeneraliste("Malalaniche", "Mélanie", "02.28.03.17.28");
        private static MedecinSpecialiste jp = new MedecinSpecialiste("Monlatin", "jean pierre", "07-66-33-06-07", "ORL", 52);
        private static Patient adhemar = new Patient("Pamamobe", "Adhémar", "0753428619", 'M', 192112192020142L,
                new DateTime(1992, 11, 21), null);

        static void Main(string[] args)
        {
            Console.WriteLine("__________________________ Médecins ______________________________");
            Console.WriteLine(melanie.ToString());
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(jp.ToString());
            Console.WriteLine("__________________________ Patients ______________________________");
            Console.WriteLine(adhemar.ToString());
            Console.WriteLine("_______________ modification du tarif du spécialiste _____________");
            jp.Tarif = 65;
            Console.WriteLine(jp.ToString());

            Console.WriteLine("_________________ ajout de commentaires au patient _______________");
            adhemar.AjouterUnCommentaire("ceci est un 1er commentaire");
            adhemar.AjouterUnCommentaire("ceci est un 2ème commentaire");
            Console.WriteLine(adhemar.ToString());

            Console.WriteLine("Appuyez sur une touche pour sortir de l'application.");
            Console.ReadKey();
        }
    }
}
