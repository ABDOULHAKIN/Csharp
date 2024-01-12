using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationCycles.BO
{

    /// <summary>
    /// Cycle est la classe de base de cette hiérarchie
    /// Elle définit les membres communs à tous les types de cycles
    /// Elle est marquée comme abstraite.
    /// Son concept est jugé trop flou pour être instanciable
    /// </summary>
    public abstract class Cycle
    {
        public DateTime DateAchat { get; set; }
        public String Marque { get; set; }
        public String Modele { get; set; }

        //Son constructeur est protégé.
        //Il reste seulement accessible par les classes filles
        protected Cycle(DateTime dateAchat, string marque, string modele)
        {
            this.DateAchat = dateAchat;
            this.Marque = marque;
            this.Modele = modele;
        }

        /// <summary>
        /// Propriété abstraite : la classe Cycle oblige toutes ses classes filles à
        /// redefinir cette propriété
        /// Une méthode abstraite ne peut être définie que dans une classe abstraite.
        /// MAIS une classe abstraite n'a pas OBLIGATOIREMENT de méthode abstraite
        /// </summary>
        public abstract double TarifLocationHeure { get; }

        public override string ToString()
        {
            //par polymorphisme, c'est toujours le TarifLocationHeure des classes filles qui sera appelé
            return $"Type : {this.GetType().Name}\n Marque : {this.Marque} Modele : {this.Modele} " +
                $"Date d'achat : {this.DateAchat.ToString("dd/MM/yyyy")} Tarif : {this.TarifLocationHeure}€/heures\n";
        }

    }
}
