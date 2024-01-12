using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuelMedecin.BO
{
    /// <summary>
    /// Décrit le concept de MedecinGeneraliste
    /// La classe doit être publique pour être visible du projet QuelMedecinApp
    /// Elle hérite de la classe Medecin. MedecinGeneraliste est donc "une sorte de" Medecin
    /// </summary>
    public class MedecinGeneraliste : Medecin
    {
        //l'attribut de classe
        //Le tarif est défini ici, car tous les Medecin partage le même tarif
        private static int tarif = 25;

        //les propriétés de classe en syntaxe simplifiée
        public static int Tarif { get => tarif; set => tarif = value; }

        //le constructeur
        /// <summary>
        /// Constructeur : crée une instance de MedecinGeneraliste
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="numeroDeTelephone"></param>
        public MedecinGeneraliste(String nom, String prenom, String numeroDeTelephone)
            :base(nom, prenom, numeroDeTelephone) //une partie du travail est déjà réalisé par un constructeur de la classe Parent Medecin 
        {

        }

        //Une méthode substituée (redéfinie)
        /// <summary>
        /// Retourne l'état d'une instance de MedecinGeneraliste 
        /// sous la forme d'une chaine de caractères formatée
        /// 
        /// Partie Personne (methode ToString() de Personne)
        /// Tarif : XX€
        /// </summary>
        public override string ToString()
        {
            //appel à la méthode ToString() de la classe Parent Medecin -> Personne 
            //pour le formatage des nom, prenom et numéro de téléphone
            return ($"{base.ToString()}Tarif : {MedecinGeneraliste.Tarif}€\n"); ;
        }
    }
}
