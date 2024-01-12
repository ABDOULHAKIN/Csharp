using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuelMedecin.BO
{
    /// <summary>
    /// Décrit le concept de Patient
    /// La classe doit être publique pour être visible du projet QuelMedecinApp
    /// Elle hérite de la classe Personne. Patient est donc "une sorte de" Personne
    /// </summary>
    public class Patient : Personne
    {
        //les attributs privés
        private char sexe;
        private long numSecu;
        private DateTime dateNaissance;
        private List<String> commentaires;

        //les propriétés d'instances en syntaxe simplifiée
        public char Sexe { get => sexe; set => sexe = value; }
        public long NumSecu { get => numSecu; set => numSecu = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }

        //la propriété Age : pas d'attribut associé, c'est une information calculée
        /// <summary>
        /// Calculer l'age du patient
        /// </summary>
        /// <return>l'age du patient ou -1 si la date de naissance n'est pas renseignée</return>
        public int Age
        {
            get
            {
                int age = -1;
                if (DateNaissance != null)
                {
                    DateTime now = DateTime.Today;
                    age = now.Year - DateNaissance.Year;
                    if (now < DateNaissance.AddYears(age)) age--;
                }

                return age;
            }
        }

        //le constructeur
        //les commentaires sont facultatifs (paramètre optionnel)
        public Patient(string nom, string prenom, string numeroDeTelephone, char sexe, long numSecu, DateTime dateNaissance, List<string> commentaires = null)
            : base(nom, prenom, numeroDeTelephone) //une partie du travail est déjà réalisé par un constructeur de la classe Parent Personne 
        {
            this.Sexe = sexe;
            this.NumSecu = numSecu;
            this.DateNaissance = dateNaissance;
            this.commentaires = commentaires;
        }

        /// <summary>
        /// Affiche à la console l'état d'une instance de Patient
        /// La méthode est marquée comme obselete
        /// NOM Prénom
        /// Téléphone : XXXXXXXXXX
        /// Sexe : Féminin ou Masculin
        /// Numéro de Sécurité sociale XXXXXXXXXXXXXXX
        /// Date de naissance : XX mois XXXX
        /// Commentaires : XXXXXXXXXXXXXXX ou [aucun commentaire]
        /// </summary>
        [Obsolete("Utilisez la méthode ToString", true)]
        public void Afficher()
        {
            //formatage du sexe pour affichage
            String sexe = (this.sexe == 'F' ? "Féminin" : "Masculin");
            //formatage de la date de naissance pour affichage
            String dateNaissance = String.Empty;
            if (this.DateNaissance != null) { 
                dateNaissance = this.DateNaissance.ToString("dd MMMM yyyy");
            }
            //formatage des commentaires pour affichage
            String commentaires = String.Empty;
            if (this.commentaires != null && this.commentaires.Count > 0) {
                foreach (String commentaire in this.commentaires)
                {
                    commentaires += $"{commentaire}\n";
                }
            }else
            {
                commentaires = "[aucun commentaire]";
            }
            Console.Write($"{this.Nom} {this.Prenom}\nTéléphone : {this.NumeroDeTelephone}\nSexe : {sexe}\n" +
                    $"Numéro de Sécurité sociale : {this.NumSecu}\nDate de naissance : {dateNaissance} (age : {this.Age})\nCommentaires : {commentaires}\n");
        }

        /// <summary>
        /// Ajouter le commentaire reçu à la liste des commentaires du Patient
        /// </summary>
        /// <param name="commentaire"></param>
        public void AjouterUnCommentaire(String commentaire)
        {
            //créer la liste des commentaires si c'est necessaire
            if (this.commentaires == null) this.commentaires = new List<string>();
            //ajouter le commentaire à la liste
            this.commentaires.Add(commentaire);
        }

        //Une méthode substituée (redéfinie)
        /// <summary>
        /// Retourne l'état d'une instance de Patient 
        /// sous la forme d'une chaine de caractères formatée
        /// Partie Personne (methode ToString() de Personne)
        /// Sexe : Féminin ou Masculin
        /// Numéro de Sécurité sociale XXXXXXXXXXXXXXX
        /// Date de naissance : XX mois XXXX
        /// Commentaires : XXXXXXXXXXXXXXX ou [aucun commentaire]
        /// </summary>
        public override string ToString()
        {
            //formatage du sexe pour affichage
            String sexe = (this.sexe == 'F' ? "Féminin" : "Masculin");
            //formatage de la date de naissance pour affichage
            String dateNaissance = String.Empty;
            if (this.DateNaissance != null)
            {
                dateNaissance = this.DateNaissance.ToString("dd MMMM yyyy");
            }
            //formatage des commentaires pour affichage
            String commentaires = String.Empty;
            if (this.commentaires != null && this.commentaires.Count > 0)
            {
                foreach (String commentaire in this.commentaires)
                {
                    commentaires += $"{commentaire}\n";
                }
            }
            else
            {
                commentaires = "[aucun commentaire]";
            }
            //appel à la méthode ToString() de la classe Parent Personne 
            //pour le formatage des nom, prenom et numéro de téléphone
            return ($"{base.ToString()}Sexe : {sexe}\n" +
                    $"Numéro de Sécurité sociale : {this.NumSecu}\nDate de naissance : {dateNaissance} (age : {this.Age})\nCommentaires : {commentaires}\n");
        }
    }
}
