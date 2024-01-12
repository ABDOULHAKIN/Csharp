using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuelMedecin.BO
{
    /// <summary>
    /// Décrit le concept de Personne
    /// La classe doit être publique pour être visible du projet QuelMedecinApp
    /// La classe est marquée abstraite, elle est donc non instanciable 
    /// (le concept est considéré comme trop flou pour permettre la création d'un objet)
    /// </summary>
    public abstract class Personne
    {
        //les attributs privés
        private String nom;
        private String prenom;
        private String numeroDeTelephone;

        //les propriétés d'instances
        public String Nom
        {
            get { return nom; }
            //la propriété set est en accès limité à la classe
            private set
            {
                if (value != null && value != String.Empty)
                {
                    value = value.ToUpper(); //formater les données
                }
                nom = value; // valorisation de l'attribut nom;
            }
        }

        public String Prenom
        {
            get { return prenom; }
            set
            {
                if (value != null && value != String.Empty)
                {
                    prenom = FormaterPrenom(value);
                }
            }
        }
        //les propriétés d'instances en syntaxe simplifiée
        public string NumeroDeTelephone { get => numeroDeTelephone; set => numeroDeTelephone = value; }

        //le constructeur
        public Personne(string nom, string prenom, string numeroDeTelephone)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.NumeroDeTelephone = numeroDeTelephone;
        }

        //une méthode de classe privée
        /// <summary>
        /// Formater le prénom
        /// </summary>
        /// <param name="prenom">le prénom à formater</param>
        /// <returns>le prénom formaté</returns>
        private static String FormaterPrenom(String prenom)
        {
            if (prenom != null && prenom != String.Empty)
            {
                String[] mots = prenom.Split(new char[] { ' ', '-' });
                prenom = String.Empty;
                foreach (String mot in mots)
                {
                    if (prenom.Length > 0) prenom += "-";
                    //la première lettre du mot passe en majuscule, les autres en minuscule.
                    prenom += mot[0].ToString().ToUpper() + mot.Substring(1, mot.Length - 1).ToLower();
                }
            }

            return prenom;
        }

        //Une méthode substituée (redéfinie)
        /// <summary>
        /// Retourne l'état d'une instance de Personne 
        /// sous la forme d'une chaine de caractères formatée
        /// NOM Prénom
        /// Téléphone : XXXXXXXXXX
        /// </summary>
        public override string ToString()
        {
            return ($"{this.Nom} {this.Prenom}\nTéléphone : {this.NumeroDeTelephone}\n");
        }
    }
}
