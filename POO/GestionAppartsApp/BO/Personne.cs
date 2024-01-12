using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApparts.BO
{
    public class Personne
    {
        public String Nom { get; set; }
        public String Prenom { get; set; }

        //attribut d'association 0..* vers Appartement en tant que propriétés
        //Une instance de personne prend la responsabilité de connaitre ses propriétés
        private List<Appartement> proprietes = new List<Appartement>();

        public Personne(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        /// <summary>
        /// ajouter l'appartement aux propriétés de l'acquereur
        /// La portée de cette méthode est limitée à ce projet (internal)
        /// </summary>
        /// <param name="appartement"></param>
        internal void AcheterAppartement(Appartement appartement)
        {
            //s'assurer que le nouveau propriétaire n'est pas déjà le propriétaire de l'appartement
            if (this != appartement.Proprietaire) { 
                //ajouter l'appartement aux propriétés de l'acquereur
                proprietes.Add(appartement);
            }
        }

        /// <summary>
        /// supprimer l'appartement des propriétés de l'ancien propriétaire
        /// La portée de cette méthode est limitée à ce projet (internal)
        /// </summary>
        /// <param name="appartement"></param>
        /// <returns></returns>
        internal bool VendreAppartement(Appartement appartement)
        {
            bool vendu = false;
            //s'assurer que le vendeur est bien le proprietaire
            if (this == appartement.Proprietaire)
            {
                //supprimer l'appartement des propriétés de l'ancien propriétaire
                proprietes.Remove(appartement);
                vendu = true;
            }
            return vendu;
        }

        public override string ToString()
        {
            String proprietesStr = String.Empty;
            foreach (Appartement appartement in proprietes)
            {
                proprietesStr += $"\n\t - Type : {appartement.Type} Surface : {appartement.Surface}";
            }
            if (proprietesStr == String.Empty)
            {
                proprietesStr = "[Aucune propriété]";
            }

            return $"Personne => {this.Nom} {this.Prenom}\n" +
                $"\tPropriétés : {proprietesStr}";
        }
    }
}
