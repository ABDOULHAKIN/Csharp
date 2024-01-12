using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuelMedecin.BO
{
    /// <summary>
    /// Décrit le concept de MedecinSpecialiste
    /// La classe doit être publique pour être visible du projet QuelMedecinApp
    /// Elle hérite de la classe Medecin. MedecinSpecialiste est donc "une sorte de" Medecin
    /// </summary>
    public class MedecinSpecialiste : Medecin
    {
        //les attributs d'instance
        private int tarif; 
        private String specialite;

        //les propriétés d'instance en syntaxe simplifiée
        public int Tarif { get => tarif; set => tarif = value; }
        public String Specialite { get => specialite; set => specialite = value; }

        //le constructeur
        /// <summary>
        /// Constructeur : crée une instance de MedecinGeneraliste
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="numeroDeTelephone"></param>
        public MedecinSpecialiste(String nom, String prenom, String numeroDeTelephone, String specialite, int tarif )
            : base(nom, prenom, numeroDeTelephone) //une partie du travail est déjà réalisé par un constructeur de la classe Parent Medecin
        {
            //le reste est à la charge de cette classe...
            this.Specialite = specialite;
            this.Tarif = tarif;
        }

        //Une méthode substituée (redéfinie)
        /// <summary>
        /// Retourne l'état d'une instance de MedecinSpecialiste 
        /// sous la forme d'une chaine de caractères formatée
        /// 
        /// Partie Personne (methode ToString() de Personne)
        /// Tarif : XX€
        /// </summary>
        public override string ToString()
        {
            //appel à la méthode ToString() de la classe Parent Medecin -> Personne 
            //pour le formatage des nom, prenom et numéro de téléphone
            return ($"{base.ToString()}Spécialité : {this.Specialite}\nTarif : {this.Tarif}€\n"); ;
        }
    }
}
