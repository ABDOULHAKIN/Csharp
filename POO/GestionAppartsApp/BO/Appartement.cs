using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApparts.BO
{
    public class Appartement
    {
        public String Type { get; set; }
        public float Surface { get; set; }

        //attribut d'association 0..1 vers Personne en tant que locataire
        //Une instance d'appartement prend la responsabilité de connaitre son locataire
        private Personne locataire;
        public Personne Locataire
        {
            get { return locataire; }
            set { locataire = value; }
        }

        //attribut d'association 0..1 vers Personne en tant que propriétaire
        //Une instance d'appartement prend la responsabilité de connaitre son propriétaire
        private Personne proprietaire;
        public Personne Proprietaire
        {
            get { return proprietaire; }
            set {
                //attention au changement de propriétaire, 
                //il faut enlever cet appartement des propriétes de l'ancien proprietaire
                //et l'ajouter aux propriétés du nouveau propriétaire
                bool transactionValide = true;
                //si cet appartement avant déjà un propriétaire
                if (proprietaire != null) {
                    transactionValide = proprietaire.VendreAppartement(this);
                }
                if (transactionValide)
                {
                    value.AcheterAppartement(this);
                    //changement de propriétaire
                    proprietaire = value;
                }
            }
        }

        public Appartement(string type, float surface)
        {
            Type = type;
            Surface = surface;
        }

        public override string ToString()
        {
            return $"Appartement => Type : {this.Type} Surface : {this.Surface}\n" +
                $"\tloué par : {this.Locataire.Nom} {this.Locataire.Prenom}\n" +
                $"\tpropriétaire : {this.Proprietaire.Nom} {this.Proprietaire.Prenom}\n";
        }
    }
}
