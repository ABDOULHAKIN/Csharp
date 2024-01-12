using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuelMedecin.BO
{
    /// <summary>
    /// Décrit le concept de Medecin
    /// La classe doit être publique pour être visible du projet QuelMedecinApp
    /// La classe est marquée abstraite, elle est donc non instanciable 
    /// (le concept est considéré comme trop flou pour permettre la création d'un objet)
    /// Elle hérite de la classe Personne. Medecin est donc "une sorte de" Personne
    /// </summary>
    public abstract class Medecin : Personne
    {

        //le constructeur
        /*
         * La classe Parent Personne n'exposant pas de constructeur par défaut,
         * la classe Medecin est dans l'obligation de surcharger le constructeur également
         */
        /// <summary>
        /// Constructeur : crée une instance de Medecin
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="numeroDeTelephone"></param>
        public Medecin(String nom, String prenom, String numeroDeTelephone)
            :base(nom, prenom, numeroDeTelephone) //une partie du travail est déjà réalisé par un constructeur de la classe Parent Personne
        {
            //la classe Medecin n'a rien à faire d'autre au cours de l'instanciation
        }


        //une méthode d'instance publique
        /// <summary>
        /// Affiche à la console l'état d'une instance de Medecin
        /// La méthode est marquée comme obselete
        /// NOM Prénom
        /// Téléphone : XXXXXXXXXX
        /// Tarif : XX€
        /// </summary>
        [Obsolete("Utilisez la méthode ToString", true)]
        public void Afficher()
        {
            Console.Write($"{this.Nom} {this.Prenom}\nTéléphone : {this.NumeroDeTelephone}\n");
        }

        //Comme la classe Medecin n'a pas d'attributs spécifiques à gérer,
        //il n'est pas necessaire de substituer la méthode ToString
    }
}
